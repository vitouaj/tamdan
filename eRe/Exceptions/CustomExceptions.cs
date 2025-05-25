namespace ERE.CustomExceptions;


[Serializable]
public class TeacherNotAvailableException : Exception
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

public class UserAlreadyExistException : Exception
{
    private static string _message = "User already exists";
    public UserAlreadyExistException() : base(_message)
    {
    }
}
[Serializable]
public class TeacherNotFoundException : Exception
{
    private const string DefaultMessage = "Teacher not found";
    public TeacherNotFoundException() : base(DefaultMessage)
    {
    }

    public TeacherNotFoundException(string? message) : base(message)
    {
    }

    public TeacherNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

[Serializable]
public class CourseReportAlreadyExistsException : Exception
{
    public CourseReportAlreadyExistsException()
    {
    }

    public CourseReportAlreadyExistsException(string? message) : base(message)
    {
    }

    public CourseReportAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
[Serializable]
public class EnrollmentNotFoundException : Exception
{
    public EnrollmentNotFoundException()
    {
    }

    public EnrollmentNotFoundException(string? message) : base(message)
    {
    }

    public EnrollmentNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

[Serializable]
public class EnrollmentAlreadyExistsException : Exception
{
    public EnrollmentAlreadyExistsException()
    {
    }

    public EnrollmentAlreadyExistsException(string? message) : base(message)
    {
    }

    public EnrollmentAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

[Serializable]
public class CourseNotFoundException : Exception
{
    public CourseNotFoundException()
    {
    }

    public CourseNotFoundException(string? message) : base(message)
    {
    }

    public CourseNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

[Serializable]
public class StudentNotFoundException : Exception
{
    public StudentNotFoundException()
    {
    }

    public StudentNotFoundException(string? message) : base(message)
    {
    }

    public StudentNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
[Serializable]
internal class InvalidRoleException : Exception
{
    private const string DefaultMessage = "Invalid role";
    public InvalidRoleException() : base(DefaultMessage)
    {
    }

    public InvalidRoleException(string? message) : base(message)
    {
    }

    public InvalidRoleException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class InvalidLoginException : Exception
{
    private static string _message = "Invalid login credentials";
    public InvalidLoginException() : base(_message)
    {
    }

    public InvalidLoginException(string message) : base(message)
    {
    }

    public InvalidLoginException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
[Serializable]
public class CourseAlreadyExistsException : Exception
{
    private const string DefaultMessage = "Course already exists";
    public CourseAlreadyExistsException() : base(DefaultMessage)
    {
    }

    public CourseAlreadyExistsException(string? message) : base(message)
    {
    }

    public CourseAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

[Serializable]
public class MainReportNotFoundException : Exception
{
    public MainReportNotFoundException()
    {
    }

    public MainReportNotFoundException(string? message) : base(message)
    {
    }

    public MainReportNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

[Serializable]
public class ContactAlreadyExistException : Exception
{
    public ContactAlreadyExistException()
    {
    }

    public ContactAlreadyExistException(string? message) : base(message)
    {
    }

    public ContactAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}