using ERE.DTO;
using Microsoft.EntityFrameworkCore;
using ERE.Infrastructure;
using ERE.Models;
using ERE.CustomExceptions;
using Microsoft.IdentityModel.Tokens;
using System.Net.Mail;
using System.Net;


namespace ERE.Repository;
public interface ITeacherRepository
{
    Task<Response> UpsertCourse(CreateCourseDto request);
    Task<Response> DeleteCourse(DeleteCourseDto deleteDto);
    Task<Response> CreateCourseReport(CreateCourseReportDto request);
    Task<Response> UpdateCourseReportsStatus(UpdateCourseReportStatusDto request);
    // Task<Response> SendCourseReportViaEmail(List<CourseReport> courseReports);

}
public class TeacherRepository(AppDbContext context, IMailService mail_service) : ITeacherRepository
{
    private readonly AppDbContext db = context;
    private readonly IMailService Mail_Service = mail_service;
    public async Task<Response> UpsertCourse(CreateCourseDto request)
    {
        // check if teacher exists
        var response = new Response();
        var occupiedHoursTobeCreate = new List<OccupiedHour>();
        var teacher = await db.Teachers
            .FirstOrDefaultAsync(t => t.UserId == request.UserId);
        if (teacher == null) {
            throw new TeacherNotFoundException();
        }
        // var availabilitiesTeacherToUpdate = new List<Availability>();
        var teacherOccupiedHours = await db.OccupiedHours
                .Where(a => a.EnitityId == teacher.Id && a.IsTeacher)
                .ToListAsync();

        var courseHoursRequested = request.CourseHours;

        // check availability of requested hours
        foreach (var courseHoure in courseHoursRequested) {
            foreach (var occupied in teacherOccupiedHours) {
                if (courseHoure.Day == occupied.DayOfWeek && courseHoure.Time == occupied.TimeOfDay) {
                    throw new TeacherNotAvailableException($"Teacher is not available on {string.Join(", ", courseHoure.Day)} at {string.Join(", ", courseHoure.Time)}");
                }
            }
        }

        // now we get that, all requested hours are available

        // check if course already exists
        var course = await db.Courses
            .FirstOrDefaultAsync(c => c.TeacherId == teacher.Id && c.LevelId == request.Level);    

        using var transaction = await db.Database.BeginTransactionAsync();
        if (course != null) {
            // update course
            course.MaxScore = request.MaxScore;
            course.PassingRate = request.PassingRate;

            foreach (var ch in courseHoursRequested) {
                var och = new OccupiedHour();
                och.CourseId = course.Id;
                och.DayOfWeek = ch.Day;
                och.TimeOfDay = ch.Time;
                och.IsTeacher = true;
                och.EnitityId = teacher.Id;
                occupiedHoursTobeCreate.Add(och);
            }
            response.Operation = OPERATION.UPDATE;
            response.Payload = new {
                Course = new {
                    Id = course.Id,
                    // CourseHours = course.CourseHours,
                    Level = course.LevelId.ToString(),
                    Subject = course.SubjectId.ToString(),
                    TeacherName = teacher.Name
                },
                OccupiedHours = occupiedHoursTobeCreate.Select(h => new {
                    h.Id,
                        h.EnitityId,
                        h.CourseId,
                        h.DayOfWeek,
                        h.TimeOfDay
                })
            };
            response.Message = "Course updated successfully";
            response.Success = true;
        } else {
            // create course
            var newCourse = new Course(teacher, request.Level);
            newCourse.MaxScore = request.MaxScore;
            newCourse.PassingRate = request.PassingRate;
            // newCourse.CourseHours = courseHoursRequested;
            db.Courses.Add(newCourse);

            foreach (var ch in courseHoursRequested) {
                var och = new OccupiedHour();
                och.CourseId = newCourse.Id;
                och.DayOfWeek = ch.Day;
                och.TimeOfDay = ch.Time;
                och.IsTeacher = true;
                och.EnitityId = teacher.Id;
                occupiedHoursTobeCreate.Add(och);
            }

            response.Operation = OPERATION.CREATE;
            response.Payload = new {
                Course = new {
                    Id = newCourse.Id,
                    // CourseHours = newCourse.CourseHours,
                    Level = newCourse.LevelId.ToString(),
                    Subject = newCourse.SubjectId.ToString(),
                    TeacherName = teacher.Name
                },
                OccupiedHours = occupiedHoursTobeCreate.Select(h => new {
                    h.Id,
                    h.EnitityId,
                    h.CourseId,
                    h.DayOfWeek,
                    h.TimeOfDay
            })
            };            
            response.Message = "Course created successfully";
            response.Success = true;
        }
        db.OccupiedHours.AddRange(occupiedHoursTobeCreate);
        await db.SaveChangesAsync();
        await transaction.CommitAsync();
        return response;
    }

    public async Task<Response> CreateCourseReport(CreateCourseReportDto request)
    {
        var response = new Response();

        // check if enrollment exists
        var enrollment = await db.Enrollments.FirstOrDefaultAsync(e => e.Id == request.EnrollmentId);
        if (enrollment == null)
        {
            throw new EnrollmentNotFoundException();
        }
        // check if course report already exists
        var courseReport = await db.CourseReports.FirstOrDefaultAsync(cr => cr.EnrollmentId == request.EnrollmentId && cr.MonthId == request.MonthId);
        if (courseReport != null)
        {
            throw new CourseReportAlreadyExistsException();
        }
        // before creating course report, create one MainReport if not exists
        var mainReport = await db.MainReports.FirstOrDefaultAsync(mr => mr.StudentId == enrollment.StudentId && mr.MonthId == request.MonthId && mr.LevelId == enrollment.LevelId);
        if (mainReport == null)
        {
            mainReport = new MainReports();
            mainReport.StudentId = enrollment.StudentId;
            mainReport.LevelId = enrollment.LevelId;
            mainReport.MonthId = request.MonthId;
            mainReport.StudentName = enrollment.StudentName;
            mainReport.StudentEmail = enrollment.StudentEmail;
            db.MainReports.Add(mainReport);
            await db.SaveChangesAsync();
        }
        // create course report
        var csReport = new CourseReport(enrollment, request.MonthId);
        csReport.MainReportId = mainReport.Id; // link to main report
        csReport.Score = request.Score;
        csReport.Absences = request.Absences;
        csReport.TeacherCmt = request.TeacherCmt;
        db.CourseReports.Add(csReport);
        await db.SaveChangesAsync();

        // asynchronously send email to student reporting this course performance
        var email = new MailData(){
            EmailToId = mainReport.StudentEmail,
            EmailSubject = "Course Report",
            EmailBody = $"Hello {mainReport.StudentName},\n\nYour course report for {request.MonthId} has been created.\n\n" +
                   $"Score: {csReport.Score}\nAbsences: {csReport.Absences}\nTeacher Comment: {csReport.TeacherCmt}\n\n" +
                   "Best regards,\nERE Team"
        };
        var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525) {
            Credentials = new NetworkCredential("ce2e673c8ab1a3", "0ac071d31fb48e"),
            EnableSsl = true
        };
        client.Send("noreply@ere-reporting.com", email.EmailToId, email.EmailSubject, email.EmailBody);

        response.Payload = csReport;
        response.Message = "Course report created successfully";
        response.Success = true;
        return response;
    }

    public async Task<Response> UpdateCourseReportsStatus(UpdateCourseReportStatusDto request) {
        var response = new Response();
        var courseIds = request.CourseReportIds;
        var courseReports = await db.CourseReports
            .Where(cr => courseIds.Contains(cr.Id))
            .ToListAsync();

        var mainReportIds = courseReports.Select(r => r.MainReportId).ToList();
        var mainReports = await db.MainReports
            .Include(m => m.CourseReports)
            .Where(m => mainReportIds.Contains(m.Id))
            .ToListAsync();

        var mainReportCourseReportMap = mainReports.ToDictionary(
            m => m.Id,
            m => m.CourseReports.ToList()
        );
        var mainReportMap = mainReports.ToDictionary(m => m.Id);

        foreach (var courseReport in courseReports) {
            courseReport.StatusId = (StatusId)request.Status;
        }
        await db.SaveChangesAsync();

        // Recalculate main report status
        foreach (var mainReportId in mainReportCourseReportMap.Keys) {
            var newStatus = RecalculateMainReportStatus(mainReportCourseReportMap[mainReportId]);
            mainReportMap[mainReportId].Status = newStatus;
        }

        await db.SaveChangesAsync();
        response.Payload = mainReportCourseReportMap.Values.ToList();
        response.Message = "Course report status updated successfully";
        response.Success = true;
        return response;
    }

    private ReportStatus RecalculateMainReportStatus(List<CourseReport> courseReports) {
        if (courseReports.IsNullOrEmpty()) {
            return ReportStatus.NOT_READY;
        }
        var allDone = courseReports.All(cr => cr.StatusId == StatusId.DONE);
        return allDone ? ReportStatus.READY : ReportStatus.NOT_READY;
    }

    public async Task<Response> DeleteCourse(DeleteCourseDto deleteDto) {
        Response response = new() { Success = false, Message = "Delete Failed" };
        if (deleteDto != null)
        {
            var courseIds = deleteDto.CourseIds;
            if (!courseIds.IsNullOrEmpty())
            {
                using var transaction = await db.Database.BeginTransactionAsync();
                try
                {
                    var affectedRows = await db.Courses
                        .Where(c => courseIds.Contains(c.Id))
                        .ExecuteDeleteAsync();

                    if (affectedRows != 0)
                    {
                        // find occupied hours and remove all
                        var occAffectedRows = await db.OccupiedHours
                            .Where(c => courseIds.Contains(c.CourseId))
                            .ExecuteDeleteAsync();

                        if (occAffectedRows != 0)
                        {
                            await transaction.CommitAsync();
                            response.Success = true;
                            response.Message = "Delete successfull!";
                        }
                    }
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }

            }
        }
        return response;
            
    }

    class CourseReportDto {
        public string Id { get; set; }
        public StatusId StatusId { get; set; }
    }

}
