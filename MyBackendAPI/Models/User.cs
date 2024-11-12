using System.ComponentModel.DataAnnotations;

namespace MyBackendAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Profile> Profile { get; set; }
        public ICollection<Order> Order { get; set; }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}