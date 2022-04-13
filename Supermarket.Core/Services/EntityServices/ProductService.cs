using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Database.Entities;
using Supermarket.Database.Repositories.Interfaces;

namespace Supermarket.Core.Services.EntityServices
{
    public class ProductService : CrudService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository) : base(repository)
        { }

        public override async Task<IEnumerable<Product>> GetAllAsync()
            => await _repository.GetQuery().Include(p => p.Category).ToListAsync();

        public async Task<IEnumerable<Product>> GetByCategoryNameAsync(string name)
            => await _repository.GetQuery().Include(p => p.Category).Where(p => p.Category.Name == name).ToListAsync();

        public override async Task<Product> GetByIdAsync(Guid id)
            => await _repository.GetQuery().Where(p => p.Id == id).Include(p => p.Category).FirstAsync();
    }
}
