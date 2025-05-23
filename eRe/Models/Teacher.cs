using System.Text.Json.Serialization;

namespace ERE.Models;

public class Teacher {

    public string Id {get ; set;} = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Email {get; set;}
    public string Phone {get; set;}
    public string UserId {get; set;}
    public List<OccupiedHour> OccupiedHours {get; set;} = new List<OccupiedHour>();
    public User User__r {get; set;} = null!;
    [JsonIgnore]
    public SubjectId SubjectId {get; private set;}

    [JsonPropertyName("SubjectId")]
    public string SubjectIdString => SubjectId.ToString();

    [JsonIgnore]
    public Subject? Subject__r {get; set;}
    public Teacher(User user, SubjectId subjectId) {
        Name = user.Firstname + " " + user.Lastname;
        Email = user.Email;
        Phone = user.Phone;
        SubjectId = subjectId;
        User__r = user;
        UserId = user.Id;
        // Availabilities = populateDefaultAvailabilities(Id);
    }

    public Teacher(User user) {
        Name = user.Firstname + " " + user.Lastname;
        Email = user.Email;
        Phone = user.Phone;
        User__r = user;
        UserId = user.Id;
        // Availabilities = populateDefaultAvailabilities(Id);
    }
    public Teacher() {
        // Availabilities = populateDefaultAvailabilities(Id);
    }

    // private static List<Availability> populateDefaultAvailabilities(string teacherId) {
    //     List<Availability> availabilities = new List<Availability>();
    //     foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek))) {
    //         foreach (TimeOfDay time in Enum.GetValues(typeof(TimeOfDay))) {
    //             availabilities.Add(new Availability { TeacherId = teacherId, DayOfWeek = day, TimeOfDay = time });
    //         }
    //     }
    //     return availabilities;
    // }
}