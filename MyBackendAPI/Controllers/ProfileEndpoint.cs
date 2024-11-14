using Microsoft.AspNetCore.Mvc;
using MyBackendAPI.DTOs.ProfileDtos;
using MyBackendAPI.DTOs.UserDtos;
using MyBackendAPI.Models;
using MyBackendAPI.Repositories;

namespace MyBackendAPI.Controllers
{
    public static class ProfileEndPoint
    {
        public static void configureProfileEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("profile");
            group.MapGet("/{id:int}", GetProfile);
            group.MapGet("/", GetAllProfiles);
            group.MapPost("/", CreateProfile);
            group.MapDelete("/{id:int}", DeleteProfile);
            group.MapPut("/{id:int}", UpdateProfile);
            group.MapPost("/createUserProfile", CreateUserAndProfile);
            group.MapPost("/getProfileByUserId", GetProfileByUserId);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllProfiles(IProfileRepository repository)
        {
            var profiles = await repository.GetProfiles();
            return TypedResults.Ok(profiles);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetProfile(IProfileRepository repository, int id)
        {
            var profile = await repository.GetProfile(id);
            if (profile == null)
            {
                return TypedResults.NotFound("Profile does not exist");
            }
            return TypedResults.Ok(profile);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetProfileByUserId(IProfileRepository repository, int userId)
        {
            try
            {
                var profile = await repository.GetProfileByUserId(userId);
                if (profile == null)
                {
                    return TypedResults.NotFound("Profile does not exist for the given UserId");
                }
                return TypedResults.Ok(profile);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateProfile(IProfileRepository repository, CreateProfileDto model)
        {
            try
            {
                Profile profileCreated = new Profile(model.FirstName, model.LastName, model.UserId, model.DateOfBirth, model.Icon, model.Points);
                await repository.CreateProfile(profileCreated);
                return TypedResults.Created("success", profileCreated);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteProfile(IProfileRepository repository, int id)
        {
            var profileDeleted = await repository.DeleteProfile(id);
            if (profileDeleted == null)
            {
                return TypedResults.NotFound("Profile does not exist");
            }
            return TypedResults.Ok(profileDeleted);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateProfile(IProfileRepository repository, CreateProfileDto model, int id)
        {
            try
            {
                var profile = await repository.GetProfile(id);
                if (profile == null)
                {
                    return TypedResults.NotFound("Profile does not exist");
                }

                profile.FirstName = model.FirstName;
                profile.LastName = model.LastName;
                profile.UserId = model.UserId;
                profile.DateOfBirth = model.DateOfBirth;
                profile.Icon = model.Icon;
                profile.Points = model.Points;

                var updatedProfile = await repository.UpdateProfile(profile);
                return TypedResults.Ok(updatedProfile);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest(e);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateUserAndProfile(IUserRepository userRepository, IProfileRepository profileRepository, string email, string password, string firstName, string lastName, DateOnly dateOfBirth)
        {
            try
            {
                // Create User
                User userCreated = new User
                {
                    Email = email,
                    Password = password
                };
                await userRepository.CreateUser(userCreated);

                // Create Profile
                Profile profileCreated = new Profile
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserId = userCreated.UserId,
                    DateOfBirth = dateOfBirth,
                    Icon = "default.png",
                    Points = 0
                };
                await profileRepository.CreateProfile(profileCreated);

                return TypedResults.Created("success", new { User = userCreated, Profile = profileCreated });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException);
                }
                return TypedResults.BadRequest(e.Message);
            }
        }
    }
}
