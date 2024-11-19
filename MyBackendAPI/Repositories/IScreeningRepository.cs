using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public interface IScreeningRepository
    {
        Task<ICollection<Screening>> GetScreenings();
        Task<Screening?> GetScreening(int id);
        Task<ICollection<Screening>> GetScreeningsByMovieId(int id);
        Task<Screening> CreateScreening(Screening screening);
        Task<Screening?> DeleteScreening(int id);
    }
}
