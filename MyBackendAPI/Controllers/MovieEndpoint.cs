using Microsoft.AspNetCore.Mvc;
using MyBackendAPI.Repositories;

namespace api_cinema_challenge.EndPoints
{

    public static class MovieEndpoint
    {
        public static void configureMovieEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("movie");
            group.MapGet("/", GetAllMovies);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllMovies(IMovieRepository repository)
        {
            var movies = await repository.GetMovies();
            return TypedResults.Ok(movies);
        }
    }

}