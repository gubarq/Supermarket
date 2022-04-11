using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Database.Entities;
using Supermarket.Database.Repositories.Interfaces;

namespace Supermarket.Core.Services.EntityServices
{
    public class ProductService : CrudService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository) : base(repository)
        {
        }
    }
}
