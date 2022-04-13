using Supermarket.Database.Entities.Base;

namespace Supermarket.Core.Services.EntityServices.Interfaces
{
    public interface ICrudService<T>
        where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
