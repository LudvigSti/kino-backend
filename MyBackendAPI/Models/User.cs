using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyBackendAPI.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public ICollection<Profile> Profile { get; set; } = new List<Profile>();
        [JsonIgnore]
        public ICollection<Order> Order { get; set; } = new List<Order>();

        public User() { }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}