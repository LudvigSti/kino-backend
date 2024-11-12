using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMovies();
    }
}
