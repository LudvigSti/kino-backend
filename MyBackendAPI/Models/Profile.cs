using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Icon { get; set; }
        public int Points { get; set; }

        public ICollection<LikedMovies> LikedMovies { get; set; }
        public ICollection<WatchedMovies> WatchedMovies { get; set; }

        public Profile(int profileId, string firstName, string lastName, int userId, DateTime dateOfBirth, string icon, int points)
        {
            ProfileId = profileId;
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            DateOfBirth = dateOfBirth;
            Icon = icon;
            Points = points;
        }
    }
}