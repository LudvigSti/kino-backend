using Microsoft.AspNetCore.Mvc;
using MyBackendAPI.DTOs.HallDtos;
using MyBackendAPI.DTOs.MovieDtos;
using MyBackendAPI.Models;
using MyBackendAPI.Repositories;

namespace MyBackendAPI.Controllers
{
    public static class HallEndpoint
    {
        public static void configureHallEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("hall");
            group.MapGet("/", GetHalls);
            group.MapGet("/{id:int}", GetHall);
            group.MapPost("/", CreateHall);
            group.MapPut("/", UpdateHall);
            group.MapDelete("/", DeleteHall);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetHalls(IHallRepository repository)
        {
            try
            {
                var halls = await repository.GetHalls();
                return TypedResults.Ok(halls);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetHall(IHallRepository repository, int id)
        {
            var movie = await repository.GetHall(id);
            if (movie == null)
            {
                return TypedResults.NotFound("Movie does not exist");
            }
            return TypedResults.Ok(movie);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateHall(IHallRepository repository, CreateHallDto model)
        {
            try
            {
                CinemaHall hall = new CinemaHall();
                hall.Name = model.Name;
                hall.Capacity = model.Capacity;

                await repository.CreateHall(hall);
                return TypedResults.Created("success", hall);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteHall(IHallRepository repository, int id)
        {
            var movieDeleted = await repository.DeleteHall(id);
            if (movieDeleted == null)
            {
                return TypedResults.NotFound("Movie does not exist");
            }
            return TypedResults.Ok(movieDeleted);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public static async Task<IResult> UpdateHall(IHallRepository repository, CreateHallDto model, int id)
        {

            try
            {
                var hall = await repository.GetHall(id);
                if (hall == null)
                {
                    return TypedResults.NotFound("Movie does not exist");
                }

                hall.Name = model.Name;
                hall.Capacity = model.Capacity;

                var updatedMovie = await repository.UpdateHall(hall);
                return TypedResults.Ok(updatedMovie);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }
    }
}
