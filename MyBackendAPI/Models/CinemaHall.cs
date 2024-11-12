using System.ComponentModel.DataAnnotations;

namespace MyBackendAPI.Models
{
    public class CinemaHall
    {
        [Key]
        public int HallId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public ICollection<Screening> Screening { get; set; }

        public CinemaHall(int hallId, string name, int capacity)
        {
            HallId = hallId;
            Name = name;
            Capacity = capacity;
        }
    }
}