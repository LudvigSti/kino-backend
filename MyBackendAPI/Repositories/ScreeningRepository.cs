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

        public async Task<ICollection<Screening>> GetScreenings()
        {
            return await _db.Screenings.ToListAsync();
        }
        public async Task<Screening?> GetScreening(int id)
        {
            return await _db.Screenings.FirstOrDefaultAsync(s => s.ScreeningId == id);
        }
        public async Task<ICollection<Screening>> GetScreeningsByMovieId(int id)
        {
            return await _db.Screenings.Include(s => s.CinemaHall).Where(s => s.MovieId == id).ToListAsync();
        }

        public async Task<Screening> CreateScreening(Screening screening)
        {
            await _db.AddAsync(screening);
            await _db.SaveChangesAsync();
            return screening;
        }

        public async Task<Screening?> DeleteScreening(int id)
        {
            Screening? screeningDeleted = await GetScreening(id);
            if (screeningDeleted == null)
            {
                return null;
            }
            _db.Remove(screeningDeleted);
            await _db.SaveChangesAsync();
            return screeningDeleted;
        }
    }
}

