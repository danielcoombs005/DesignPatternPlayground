using DesignPatternsPlayground.Models;

namespace DesignPatternsPlayground.Services
{
    public interface IUserService
    {
        Task<User> GetUser(int id);
        Task<List<User>> GetAllUsers();
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user, int id);
        Task<bool> DeleteUser(int id);
    }
}
