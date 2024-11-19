using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyBackendAPI.Models
{
    [Table("CinemaHall")]
    public class CinemaHall
    {
        [Key]
        public int HallId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        [JsonIgnore]
        public ICollection<Screening> Screening { get; set; }

        public CinemaHall() { }

        public CinemaHall(int hallId, string name, int capacity)
        {
            HallId = hallId;
            Name = name;
            Capacity = capacity;
        }
    }
}