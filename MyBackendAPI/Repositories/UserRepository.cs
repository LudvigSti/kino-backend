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

        public async Task<User> CreateUser(User user)
        {
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        } 
    }
}
