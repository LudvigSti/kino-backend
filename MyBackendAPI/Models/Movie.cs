using System.ComponentModel.DataAnnotations;

namespace MyBackendAPI.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public int AgeRating { get; set; }
        public int Duration { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Image { get; set; }

        public ICollection<MovieWithGenre> MovieWithGenres { get; set; }
        public ICollection<LikedMovies> LikedMovies { get; set; }
        public ICollection<WatchedMovies> WatchedMovies { get; set; }
        public ICollection<Screening> Screenings { get; set; }

        public Movie (int movieId, string title, int rating, int ageRating, int duration, int releaseYear, string director, string image)
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