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

        public async Task<Movie?> GetMovie(int id)
        {
            return await _db.Movies.FirstOrDefaultAsync(x => x.MovieId == id);
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            await _db.AddAsync(movie);
            await _db.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> DeleteMovie(int id)
        {
            Movie? movieDeleted = await GetMovie(id);
            if(movieDeleted == null)
            {
                return null;
            }
            _db.Remove(movieDeleted);
            await _db.SaveChangesAsync();
            return movieDeleted;
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            await _db.SaveChangesAsync();
            return movie;
        }
    }
}
