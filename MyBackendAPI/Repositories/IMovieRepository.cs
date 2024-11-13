using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMovies();

        Task<Movie> CreateMovie(Movie movie);
        Task<Movie?> GetMovie(int id);
        Task<Movie?> DeleteMovie(int id);
        Task<Movie> UpdateMovie(Movie movie);
    }
}
