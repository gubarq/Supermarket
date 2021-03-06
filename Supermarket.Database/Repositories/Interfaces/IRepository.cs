namespace Supermarket.Database.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        IQueryable<T> GetQuery();

        Task CreateOrUpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
