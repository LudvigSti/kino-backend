

namespace MyBackendAPI.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int movieId { get; set; }
        public Movie Movie { get; set; }
        
    }
}

