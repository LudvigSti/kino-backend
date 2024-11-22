using Microsoft.AspNetCore.Mvc;
using MyBackendAPI.DTOs.MovieDtos;
using MyBackendAPI.DTOs.UserDtos;
using MyBackendAPI.Models;
using MyBackendAPI.Repositories;

namespace api_cinema_challenge.EndPoints
{

    public static class MovieEndpoint
    {
        public static void configureMovieEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("movie");
            group.MapGet("/", GetAllMovies);
            group.MapGet("/{id:int}", GetMovie);
            group.MapPost("/", CreateMovie);
            group.MapDelete("/{id:int}", DeleteMovie);
            group.MapPut("/{id:int}", UpdateMovie);
            group.MapPut("/Image{id:int}", UpdateMovieImage);
            group.MapPut("AddImage{id:int}",AddLandscapeImageToMovie);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllMovies(IMovieRepository repository)
        {
            var movies = await repository.GetMovies();
            return TypedResults.Ok(movies);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetMovie(IMovieRepository repository, int id)
        {
            var movie = await repository.GetMovie(id);
            if (movie == null)
            {
                return TypedResults.NotFound("Movie does not exist");
            }
            return TypedResults.Ok(movie);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateMovie(IMovieRepository repository, CreateMovieDto model)
        {
            try
            {
                Movie movieCreated = new Movie();
                movieCreated.Title = model.Title;
                movieCreated.Rating = model.Rating;
                movieCreated.AgeRating = model.Rating;
                movieCreated.Duration = model.Duration;
                movieCreated.ReleaseDate = model.ReleaseDate;
                movieCreated.Director = model.Director;
                movieCreated.Trailer = model.Trailer;
                
                await repository.CreateMovie(movieCreated);
                return TypedResults.Created("success", movieCreated);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(new { Error = "An error occurred while processing your request.", Details = e.Message });
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteMovie(IMovieRepository repository, int id)
        {
            var movieDeleted = await repository.DeleteMovie(id);
            if (movieDeleted == null)
            {
                return TypedResults.NotFound("Movie does not exist");
            }
            return TypedResults.Ok(movieDeleted);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public static async Task<IResult> UpdateMovie(IMovieRepository repository, CreateMovieDto model, int id)
        {

            try
            {
                var movie = await repository.GetMovie(id);
                if (movie == null)
                {
                    return TypedResults.NotFound("Movie does not exist");
                }

                movie.Title = model.Title;
                movie.Rating = model.Rating;
                movie.AgeRating = model.Rating;
                movie.Duration = model.Duration;
                movie.ReleaseDate = model.ReleaseDate;
                movie.Director = model.Director;

                var updatedMovie = await repository.UpdateMovie(movie);
                return TypedResults.Ok(updatedMovie);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }
        public static async Task<IResult> UpdateMovieImage(IMovieRepository repository, int id, string image, int imagePosition)
        {

            try
            {
                var movie = await repository.GetMovie(id);
                if (movie == null)
                {
                    return TypedResults.NotFound("Movie does not exist");
                }


                movie.Images[imagePosition] = image;

                var updatedMovie = await repository.UpdateMovie(movie);
                return TypedResults.Ok(updatedMovie);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddLandscapeImageToMovie(IMovieRepository repository, int id, string imageUrl)
        {
            try
            {
                // Fetch the movie by ID
                var movie = await repository.GetMovie(id);
                if (movie == null)
                {
                    return TypedResults.NotFound("Movie does not exist");
                }

                // Append the new image URL to the Images list
                if (movie.Images == null)
                {
                    movie.Images = new List<string>(); // Ensure Images list is initialized
                }
                movie.Images.Add(imageUrl);

                // Update the movie in the repository
                var updatedMovie = await repository.UpdateMovie(movie);
                return TypedResults.Ok(updatedMovie);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(new { Error = "An error occurred while processing your request.", Details = e.Message });
            }
        }
    }

}

