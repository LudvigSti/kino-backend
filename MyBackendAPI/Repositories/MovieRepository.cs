using MyBackendAPI.Data;
using MyBackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MyBackendAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private CinemaContext _db;

        public MovieRepository(CinemaContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Movie>> GetMovies()
        {
            return await _db.Movies.ToListAsync();
        }
    }
}
