using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public interface IProfileRepository
    {
        Task<ICollection<Profile>> GetProfiles();
        Task<Profile> GetProfileByUserId(int userId);
        Task<Profile> GetProfileByEmail(string email);
        Task<Profile> CreateProfile(Profile profile);
        Task<Profile?> GetProfile(int id);
        Task<Profile?> DeleteProfile(int id);
        Task<Profile> UpdateProfile(Profile profile);
    }
}
