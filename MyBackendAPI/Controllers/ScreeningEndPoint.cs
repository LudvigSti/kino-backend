using Microsoft.AspNetCore.Mvc;
using MyBackendAPI.DTOs;
using MyBackendAPI.Models;
using MyBackendAPI.Repositories;

namespace MyBackendAPI.Controllers
{
    public static class ScreeningEndPoint
    {
        public static void configureScreeningEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("screening");
            group.MapGet("/", GetScreenings);
            group.MapGet("/{id:int}", GetScreening);
            group.MapGet("/getScreeningsByMovieId/{movieId:int}", GetScreeningsByMovieId);
            group.MapPost("/", CreateScreening);
            group.MapDelete("/{id:int}", DeleteScreening);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetScreenings(IScreeningRepository repository)
        {
            var screenings = await repository.GetScreenings();
            return TypedResults.Ok(screenings);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetScreening(IScreeningRepository repository, int id)
        {
            var screening = await repository.GetScreening(id);
            if(screening == null)
            {
                return TypedResults.NotFound("Screening does not exist");
            }

            return TypedResults.Ok(screening);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetScreeningsByMovieId(IScreeningRepository screeningRepository, IMovieRepository movieRepository, int movieId)
        {
            try
            {
                var movie = await movieRepository.GetMovie(movieId);

                if(movie == null)
                {
                    return TypedResults.NotFound("Movie does not exist");
                }

                var screenings = await screeningRepository.GetScreeningsByMovieId(movieId);
                return TypedResults.Ok(screenings);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateScreening(IScreeningRepository screeningRepository, IMovieRepository movieRepository, IHallRepository hallRepository, CreateScreeningDto model)
        {
            try
            {
                var movie = await movieRepository.GetMovie(model.movieId);
                var hall = await hallRepository.GetHall(model.hallId);

                if(movie == null || hall == null)
                {
                    return TypedResults.NotFound("Movie and hall must exist");
                }

                Screening screening = new Screening(model.StartTime, model.hallId, model.movieId, model.About);
                var screeningCreated = await screeningRepository.CreateScreening(screening);
                return TypedResults.Ok(screeningCreated);
            }
            catch(Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }

        public static async Task<IResult> DeleteScreening(IScreeningRepository repository, int id)
        {
            var screeningDeleted = await repository.GetScreening(id);
            if(screeningDeleted == null)
            {
                return TypedResults.NotFound("Screening id does not exist");
            }

            await repository.DeleteScreening(id);
            return TypedResults.Ok(screeningDeleted);
        }
    }
}
