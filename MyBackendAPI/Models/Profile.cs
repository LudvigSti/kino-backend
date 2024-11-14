using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyBackendAPI.Models
{
    [Table("Profile")]
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public DateOnly DateOfBirth { get; set; }
        public string Icon { get; set; }
        public int Points { get; set; }

        [JsonIgnore]
        public ICollection<LikedMovie> LikedMovie { get; set; }
        [JsonIgnore]
        public ICollection<WatchedMovie> WatchedMovie { get; set; }

        public Profile() { }

        public Profile(string firstName, string lastName, int userId, DateOnly dateOfBirth, string icon, int points)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            DateOfBirth = dateOfBirth;
            Icon = icon;
            Points = points;
        }
    }
}