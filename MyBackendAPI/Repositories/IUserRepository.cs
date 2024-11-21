using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetUsers();
        Task<User> CreateUser(User user);
        Task<User?> GetUser(int id);
        Task<User?> DeleteUser(int id);
        Task<User> UpdateUser(User user);
        Task<User> GetUserByEmail(string email);
    }
}
