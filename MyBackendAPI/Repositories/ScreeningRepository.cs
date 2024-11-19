using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Data;
using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public class ScreeningRepository : IScreeningRepository
    {
        private CinemaContext _db;

        public ScreeningRepository(CinemaContext db)
        {
            _db = db;
        }
        public async Task<ICollection<Screening>> GetScreeningsByMovieId(int id)
        {
            return await _db.Screenings.Where(s => s.MovieId == id).ToListAsync();
        }

        public async Task<Screening> CreateScreening(Screening screening)
        {
            await _db.AddAsync(screening);
            await _db.SaveChangesAsync();
            return screening;
        }
    }
}

