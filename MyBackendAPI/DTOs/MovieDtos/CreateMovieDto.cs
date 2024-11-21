using MyBackendAPI.Models;

namespace MyBackendAPI.DTOs.MovieDtos
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public int AgeRating { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Image { get; set; }
        public string Trailer { get; set; }

    }
}
