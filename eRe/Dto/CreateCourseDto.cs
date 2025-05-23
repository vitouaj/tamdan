using ERE.Models;
using static ERE.Models.Course;

namespace ERE.DTO;

public class CreateCourseDto
{
    public string UserId { get; set; }
    public LevelId Level { get; set; }
    public float MaxScore { get; set; }
    public float PassingRate { get; set; }
    public List<CourseHour> CourseHours { get; set; } = new List<CourseHour>();
}

 public class CourseHour {
    public Models.DayOfWeek Day {get; set;}
    public TimeOfDay Time {get; set;}
}