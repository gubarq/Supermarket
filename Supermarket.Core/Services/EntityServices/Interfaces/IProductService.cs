using Supermarket.Database.Entities;

namespace Supermarket.Core.Services.EntityServices.Interfaces
{
    public interface IProductService : ICrudService<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryNameAsync(string name);
    }
}
