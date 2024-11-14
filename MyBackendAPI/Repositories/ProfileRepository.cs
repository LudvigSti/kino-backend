using MyBackendAPI.Data;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly CinemaContext _db;

        public ProfileRepository(CinemaContext db)
        {
            _db = db;
        }
        public async Task<ICollection<Profile>> GetProfiles()
        {
            return await _db.Profiles.ToListAsync();
        }

        public async Task<Profile?> GetProfile(int id)
        {
            return await _db.Profiles.FirstOrDefaultAsync(x => x.ProfileId == id);
        }
        public async Task<Profile> CreateProfile(Profile profile)
        {
            await _db.AddAsync(profile);
            await _db.SaveChangesAsync();
            return profile;
        }

        public async Task<Profile?> DeleteProfile(int id)
        {
            Profile? profileDeleted = await GetProfile(id);
            if(profileDeleted == null) 
            {
                return null;
            }
            _db.Remove(profileDeleted);
            await _db.SaveChangesAsync();
            return profileDeleted;
        }

        public async Task<Profile> UpdateProfile(Profile profile)
        {
            _db.Update(profile);
            await _db.SaveChangesAsync();
            return profile;
        }
    }
}
