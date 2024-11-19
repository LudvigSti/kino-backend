using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public interface IScreeningRepository
    {
        Task<ICollection<Screening>> GetScreeningsByMovieId(int id);
        Task<Screening> CreateScreening(Screening screening);
    }
}
