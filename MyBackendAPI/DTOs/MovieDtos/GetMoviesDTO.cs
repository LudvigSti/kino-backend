namespace MyBackendAPI.DTOs.MovieDtos
{
    public class GetMoviesDTO
    {
        
            public int MovieId { get; set; }
            public string Title { get; set; }
            public int Rating { get; set; }
            public int AgeRating { get; set; }
            public int Duration { get; set; }
            public DateTime ReleaseYear { get; set; }
            public string Director { get; set; }
            public string ImageUrls { get; set; }
        
    }
}
