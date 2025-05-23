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
    Task<Response> CreateCourseReport(CreateCourseReportDto request);
    // Task<Response> RemoveCourse(string courseId);
    Task<Response> UpdateCourseReportsStatus(UpdateCourseReportStatusDto request);
    // Task<Response> SendCourseReportViaEmail(List<CourseReport> courseReports);

}
public class TeacherRepository(AppDbContext context, IMailService mail_service) : ITeacherRepository
{
    private readonly AppDbContext db = context;

    private readonly IMailService Mail_Service = mail_service;

    // public async Task<Response> RemoveCourse(string courseId)
    // {
    //     var response = new Response();

    //     using var transaction = await db.Database.BeginTransactionAsync();
    //     var course = await db.Courses
    //         .FirstOrDefaultAsync(c => c.Id == courseId);
    //     if (course == null) {
    //         throw new CourseNotFoundException();
    //     }
    //     // restore teacher availability
    //     var availabilities = await db.Availabilities
    //         .Where(a => a.TeacherId == course.TeacherId && a.CourseId == course.Id && a.Status == AvailabilityStatus.UNAVAILABLE)
    //         .ToListAsync();

    //     foreach (var availability in availabilities) {
    //         if (availability.Status == AvailabilityStatus.UNAVAILABLE) {
    //             availability.Status = AvailabilityStatus.AVAILABLE;
    //         }
    //     }
    //     db.Availabilities.UpdateRange(availabilities);
    //     // remove course
    //     db.Courses.Remove(course);
    //     await db.SaveChangesAsync();
    //     await transaction.CommitAsync();
    //     response.Message = "Course removed successfully";
    //     response.Success = true;
    //     return response;
    // }

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

// Check if teacher is available for the given days and times
    // If the teacher is available, return null, otherwise return not available days and times
    // private async Task<List<Availability>> getTeacherAvailability(string teacherId, List<Models.DayOfWeek> days, List<TimeOfDay> times) {
    //     var teacherAvailability = await db.Availabilities
    //         .Where(a => a.TeacherId == teacherId && a.Status == AvailabilityStatus.AVAILABLE)
    //         .ToListAsync();
        
    //     var availabilitiesTeacherToUpdate = new List<Availability>();
    //     foreach (var day in days) {
    //         foreach (var time in times) {
    //             var availability = teacherAvailability.FirstOrDefault(a => a.DayOfWeek == day && a.TimeOfDay == time); // contain
    //             if (availability == null) throw new TeacherNotAvailableException($"Teacher is not available on {day.ToString()} at {time.ToString()}");    
    //             availabilitiesTeacherToUpdate.Add(availability);
    //         }
    //     }
    //     return availabilitiesTeacherToUpdate;
    // }

    private ReportStatus RecalculateMainReportStatus(List<CourseReport> courseReports) {
        if (courseReports.IsNullOrEmpty()) {
            return ReportStatus.NOT_READY;
        }
        var allDone = courseReports.All(cr => cr.StatusId == StatusId.DONE);
        return allDone ? ReportStatus.READY : ReportStatus.NOT_READY;
    }
    class CourseReportDto {
        public string Id { get; set; }
        public StatusId StatusId { get; set; }
    }

}

[Serializable]
internal class TeacherNotAvailableException : Exception
{
    public TeacherNotAvailableException()
    {
    }

    public TeacherNotAvailableException(string? message) : base(message)
    {
    }

    public TeacherNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

public class UpdateCourseReportStatusDto {
    public List<string> CourseReportIds { get; set; }
    public ReportStatus Status { get; set; }
}
