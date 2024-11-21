using MyBackendAPI.Data;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CinemaContext _db;

        public UserRepository(CinemaContext db)
        {
            _db = db;
        }
        public async Task<ICollection<User>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetUser(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }
        public async Task<User> CreateUser(User user)
        {
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteUser(int id)
        {
            User? userDeleted = await GetUser(id);
            if(userDeleted == null) 
            {
                return null;
            }
            _db.Remove(userDeleted);
            await _db.SaveChangesAsync();
            return userDeleted;
        }

        public async Task<User> UpdateUser(User user)
        {
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email)!;
        }
    }
}
