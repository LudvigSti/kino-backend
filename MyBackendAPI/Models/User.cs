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
        public Profile Profile { get; set; }

        [JsonIgnore]
        public ICollection<Order> Order { get; set; } = new List<Order>();

        public User() { }

        public User(string email, string password)
        {
            Email = email;
            Password = HashPassword(password);
        }

        private string HashPassword(string password)
        {
           return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }
}