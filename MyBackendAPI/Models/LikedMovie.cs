using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    [Table("LikedMovie")]
    public class LikedMovie
    {
        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public LikedMovie(int profileId, int movieId)
        {
            ProfileId = profileId;
            MovieId = movieId;
        }
    }
}