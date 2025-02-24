using DesignPatternsPlayground.Models;
using DesignPatternsPlayground.Patterns;

namespace DesignPatternsPlayground.Repositories
{
    public class DBRepository<T> : IDBRepository<T> where T : class
    {
        private readonly MyDbContext _context;

        public DBRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                var value = await _context.FindAsync<T>(id);
                return value;
            }
            catch
            {
                throw new Exception($"Item not found: {id}.");
            }
        }

        public async Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(T entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
