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
            group.MapGet("/{id:int}", GetUser);
            group.MapGet("/", GetAllUsers);
            group.MapPost("/", CreateUser);
            group.MapDelete("/", DeleteUser);
            group.MapPut("/{id:int}", UpdateUser);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllUsers(IUserRepository repository)
        {
            var users = await repository.GetUsers();
            return TypedResults.Ok(users);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetUser(IUserRepository repository, int id)
        {
            var user = await repository.GetUser(id);
            if(user == null)
            {
                return TypedResults.NotFound("User does not exist");
            }
            return TypedResults.Ok(user);
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteUser(IUserRepository repository, int id)
        {
            var userDeleted = await repository.DeleteUser(id);
            if(userDeleted == null)
            {
                return TypedResults.NotFound("User does not exist");
            }
            return TypedResults.Ok(userDeleted);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public static async Task<IResult> UpdateUser(IUserRepository repository, CreateUserDto model, int id)
        {
            
            try
            {
                var user = await repository.GetUser(id);
                if (user == null)
                {
                    return TypedResults.NotFound("User does not exist");
                }

                user.Email = model.Email;
                user.Password = model.Password;

                var updatedUser = await repository.UpdateUser(user);
                return TypedResults.Ok(updatedUser);
            }
            catch(Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }

    }
}
