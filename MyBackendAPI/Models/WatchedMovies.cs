using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    public class WatchedMovies
    {
        [Key]
        public int WatchedMoviesId { get; set; }

        public int ProfileId { get; set; }
        [ForeignKey("Profile")]
        public Profile Profile { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("Movie")]
        public Movie Movie { get; set; }

        public WatchedMovies(int watchedMoviesId, int profileId, int movieId)
        {
            WatchedMoviesId = watchedMoviesId;
            ProfileId = profileId;
            MovieId = movieId;
        }
    }
}