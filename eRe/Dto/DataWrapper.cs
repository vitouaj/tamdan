using System.ComponentModel.DataAnnotations;
using ERE.Models;

namespace ERE.DTO;

public class ContactDto {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    public string HomeNumber { get; set; }
    public string Street { get; set; }
    public string Village { get; set; }
    public string Commune { get; set; }
    public string District { get; set; }
    public string Province { get; set; }

}

public class CourseReportDto
{
    public string Id { get; set; }
    public string MainReportId { get; set; }
    public string StatusId { get; set; }
    public string TeacherName { get; set; }
    public float Score { get; set; }
    public int Absences { get; set; }
    public string? Subject { get; set; }
    public string TeacherId { get; set; }
    public string TeacherCmt { get; set; }
}

public class MainReportDto
{
    public string Id { get; set; }
    public string StudentId { get; set; }
    public string StudentName { get; set; }
    public string StudentEmail { get; set; }
    public MonthId MonthId { get; set; }
    public LevelId LevelId { get; set; }
    public string Status { get; set; }
    public string ParentCmt { get; set; }
    public HashSet<CourseReportDto> CourseReports { get; set; } = new();

    // Recalculated total absence
    public int TotalAbsence => CourseReports?.Sum(r => r.Absences) ?? 0;
    public float TotalScore => CourseReports?.Sum(r => r.Score) ?? 0;

    // Recalculated total score (e.g., average)
    public float AverageScore => CourseReports != null && CourseReports.Count > 0
        ? CourseReports.Average(r => r.Score)
        : 0f;

    // Recalculated overall grade (e.g., average or based on rules)
    public string OverallGrade
    {
        get
        {
            if (CourseReports == null || CourseReports.Count == 0)
                return "N/A";

            var average = AverageScore;

            // Example logic
            if (average >= 90) return GradeId.A.ToString();
            if (average >= 80) return GradeId.B.ToString();
            if (average >= 70) return GradeId.C.ToString();
            if (average >= 60) return GradeId.D.ToString();
            if (average >= 50) return GradeId.E.ToString();
            return GradeId.F.ToString();
        }
    }
}

public class FoundEntity
{
    public Student Student = new Student();
    public Course Course = new Course();
}

public class GetMainReportDto
{
    public string StudentId { get; set; }
    public List<string> StudentIds { get; set; }
    public MonthId? MonthId { get; set; }
    public LevelId? LevelId { get; set; }
}


public class ProvideFeedbackDto
{
    public string MainReportId { get; set; }
    public string Feedback { get; set; }
}

public class UpdateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class UpdateCourseReportStatusDto {
    public List<string> CourseReportIds { get; set; }
    public ReportStatus Status { get; set; }
}

public class CreateCourseDto
{
    public string UserId { get; set; }
    public LevelId Level { get; set; }
    public float MaxScore { get; set; }
    public float PassingRate { get; set; }
    public List<CourseHour> CourseHours { get; set; } = new List<CourseHour>();
}

public class DeleteCourseDto
{
    public List<string> CourseIds { get; set; } = new List<string>();
}

public class CourseHour
{
    public Models.DayOfWeek Day { get; set; }
    public TimeOfDay Time { get; set; }
}

public class CreateCourseReportDto
{
    public string EnrollmentId { get; set; }
    public MonthId MonthId { get; set; }
    public float Score { get; set; }
    public int Absences { get; set; }
    public string? TeacherCmt { get; set; }
}

public class EnrollmentDto
{
    public string StudentId { get; set; }
    public string CourseId { get; set; }
}

public class GetUserResponse
{
    public string UserID { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Phonenumber { get; set; }
    public string ParentEmail { get; set; }
    public string Role { get; set; }
}

public class LoginRequestDto
{
    public string? EmailOrPhoneNumber { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
    public string? DeviceId { get; set; }
    public string? DeviceName { get; set; }
    public string? DeviceType { get; set; }
    public string? DeviceOs { get; set; }
    public string? IPAddress { get; set; }
}
public class MailData
{
    public string EmailToId { get; set; }
    public string EmailToName { get; set; }
    public string EmailSubject { get; set; }
    public string EmailBody { get; set; }
}
public class RegisterRequestDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public LevelId? LevelId { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(50)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
    public string Password { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public RoleId Role { get; set; }
    public SubjectId? Subject { get; set; }
    public List<ContactDto>? Contacts { get; set; } = new List<ContactDto>();
}

public class Response
{
    public Response(bool success, object payload, string message)
    {
        Success = success;
        Payload = payload;
        Message = message;
    }
    public Response() { }
    public bool? Success { get; set; }
    public object? Payload { get; set; }
    public string? Message { get; set; }
    public OPERATION Operation { get; set; }
}
public enum OPERATION
{
    CREATE = 1,
    UPDATE = 2,
    DELETE = -1
}

