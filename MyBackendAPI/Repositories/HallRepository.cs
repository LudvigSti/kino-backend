using MyBackendAPI.Data;
using MyBackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MyBackendAPI.Repositories
{
    public class HallRepository : IHallRepository
    {

        private CinemaContext _db;

        public HallRepository(CinemaContext db)
        {
            _db = db;
        }

        public async Task<ICollection<CinemaHall>> GetHalls()
        {
            return await _db.CinemaHalls.ToListAsync();
        }

        public async Task<CinemaHall?> GetHall(int id)
        {
            return await _db.CinemaHalls.FirstOrDefaultAsync(x => x.HallId == id);
        }

        public async Task<CinemaHall> CreateHall(CinemaHall hall)
        {
            await _db.AddAsync(hall);
            await _db.SaveChangesAsync();
            return hall;
        }

        public async Task<CinemaHall> UpdateHall(CinemaHall hall)
        {
            await _db.SaveChangesAsync();
            return hall;
        }

        public async Task<CinemaHall?> DeleteHall(int id)
        {
            CinemaHall? hallDeleted = await GetHall(id);
            if (hallDeleted == null)
            {
                return null;
            }
            _db.Remove(hallDeleted);
            await _db.SaveChangesAsync();
            return hallDeleted;
        }
    }

}
