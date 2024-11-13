using MyBackendAPI.Models;

namespace MyBackendAPI.Repositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetUsers();
        Task<User> CreateUser(User user);
    }
}
