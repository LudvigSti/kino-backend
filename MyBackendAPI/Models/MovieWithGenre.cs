using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    public class MovieWithGenre{

        [Key]
        public int MWGId { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        
        public string GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        public MovieWithGenre(int mwgId, int movieId, string genreId)
        {
            MWGId = mwgId;
            MovieId = movieId;
            GenreId = genreId;
        }
    }
}