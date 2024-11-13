using Microsoft.AspNetCore.Mvc;
using MyBackendAPI.DTOs.UserDtos;
using MyBackendAPI.Models;
using MyBackendAPI.Repositories;

namespace MyBackendAPI.Controllers
{
    public static class UserEndPoint
    {
        public static void configureUserEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("user");
            group.MapGet("/", GetAllUsers);
            group.MapPost("/", CreateUser);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllUsers(IUserRepository repository)
        {
            var users = await repository.GetUsers();
            return TypedResults.Ok(users);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateUser(IUserRepository repository, CreateUserDto model)
        {
            try
            {
                User userCreated = new User(model.Email, model.Password);
                await repository.CreateUser(userCreated);
                return TypedResults.Created("success", userCreated);
            }
            catch(Exception e)
            {
                return TypedResults.BadRequest(e);
            }

        }
    }
}
