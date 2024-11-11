namespace MyBackendAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }

        public Movie (int id, string title, string genre, int releaseYear, string director)
        {
            Id = id;
            Title = title;
            Genre = genre;
            ReleaseYear = releaseYear;
            Director = director;
        }
    }

}