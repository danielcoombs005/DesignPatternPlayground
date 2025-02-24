using DesignPatternsPlayground.Models;
using DesignPatternsPlayground.Repositories;

namespace DesignPatternsPlayground.Services
{
    public class UserService : IUserService
    {
        private readonly IDBRepository<User> _dbRepository;
        
        public UserService(IDBRepository<User> dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<User> GetUser(int id)
        {
            return await _dbRepository.GetById(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbRepository.GetAll();
        }

        public async Task<bool> CreateUser(User user)
        {
            return await _dbRepository.Create(user);
        }

        public async Task<bool> UpdateUser(User user, int id)
        {
            return await _dbRepository.Update(user, id);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _dbRepository.Delete(id);
        }
    }
}
