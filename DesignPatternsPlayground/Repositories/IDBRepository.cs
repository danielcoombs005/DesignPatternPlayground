namespace DesignPatternsPlayground.Repositories
{
    public interface IDBRepository<T>
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();

        Task<bool> Create(T entity);
        Task<bool> Update(T entity, int id);
        Task<bool> Delete(int id);

    }
}
