using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Database.Entities.Base;
using Supermarket.Database.Repositories.Interfaces;

namespace Supermarket.Core.Services.EntityServices
{
    public class CrudService<T> : ICrudService<T>
        where T : BaseEntity
    {
        protected IRepository<T> _repository;

        public CrudService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task CreateAsync(T entity)
            => await _repository.CreateOrUpdateAsync(entity);

        public virtual async Task UpdateAsync(T entity)
            => await _repository.CreateOrUpdateAsync(entity);

        public virtual async Task DeleteAsync(T entity)
            => await _repository.DeleteAsync(entity);

        public virtual async Task<List<T>> GetAllAsync()
            => await _repository.GetQuery().ToListAsync();

        public virtual async Task<T> GetByIdAsync(Guid id)
            => await _repository.GetByIdAsync(id);
    }
}
