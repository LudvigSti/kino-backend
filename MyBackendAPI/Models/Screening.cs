using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    [Table("Screening")]
    public class Screening
    {
        [Key]
        public int ScreeningId { get; set; }
        public DateTime ScreeningTime { get; set; }

        public int HallId { get; set; }
        [ForeignKey("HallId")]
        public CinemaHall CinemaHall { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        

        public Screening(int screeningId, DateTime screeningTime, int hallId, int movieId)
        {
            ScreeningId = screeningId;
            ScreeningTime = screeningTime;
            HallId = hallId;
            MovieId = movieId;
        }

    }
}