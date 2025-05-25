namespace ERE.Models;

// is the occupied hours
public class OccupiedHour {
    public string Id {get; set;} = Guid.NewGuid().ToString();
    public Boolean IsStudent {get; set;}
    public Boolean IsTeacher {get; set;}
    public string EnitityId {get; set;} = null!;
    public string CourseId {get; set;} = null!;
    // public AvailabilityStatus Status {get; set;} = AvailabilityStatus.AVAILABLE;
    public DayOfWeek DayOfWeek { get; set; } 
    public TimeOfDay TimeOfDay {get; set;}


}

// public enum AvailabilityStatus {
//     UNAVAILABLE = 0, AVAILABLE
// }