using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public interface IHallRepository
    {
        Task<ICollection<CinemaHall>> GetHalls();
        Task<CinemaHall?> GetHall(int id);
        Task<CinemaHall> CreateHall(CinemaHall hall);
        Task<CinemaHall?> DeleteHall(int id);
        Task<CinemaHall> UpdateHall(CinemaHall hall);
    }
}
