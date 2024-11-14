using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyBackendAPI.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public int AgeRating { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Image { get; set; }

        //TODO:
        //Make DTO's for theese
        [JsonIgnore]
        public ICollection<MovieWithGenre> MovieWithGenres { get; set; } = new List<MovieWithGenre>();
        [JsonIgnore]
        public ICollection<LikedMovie> LikedMovie { get; set; } = new List<LikedMovie>();
        [JsonIgnore]
        public ICollection<WatchedMovie> WatchedMovie { get; set; } = new List<WatchedMovie>();
        [JsonIgnore]
        public ICollection<Screening> Screenings { get; set; } = new List<Screening>();

        public Movie() { }
        public Movie (int movieId, string title, int rating, int ageRating, int duration, DateTime releaseYear, string director, string image)
        {
            MovieId = movieId;
            Title = title;
            Rating = rating;
            AgeRating = ageRating;
            Duration = duration;
            ReleaseYear = releaseYear;
            Director = director;
            Image = image;
        }
    }

}