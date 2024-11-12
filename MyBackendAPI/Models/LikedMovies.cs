using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    public class LikedMovies
    {
        [Key]
        public int LikedMoviesId { get; set; }

        public int ProfileId { get; set; }
        [ForeignKey("Profile")]
        public Profile Profile { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("Movie")]
        public Movie Movie { get; set; }

        public LikedMovies(int likedMoviesId, int profileId, int movieId)
        {
            LikedMoviesId = LikedMoviesId;
            ProfileId = profileId;
            MovieId = movieId;
        }
    }
}