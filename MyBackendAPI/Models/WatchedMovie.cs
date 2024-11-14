using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    [Table("WatchedMovie")]
    public class WatchedMovie
    {
        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public WatchedMovie(int profileId, int movieId)
        {
            ProfileId = profileId;
            MovieId = movieId;
        }
    }
}