using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Database.Entities;
using Supermarket.Database.Repositories.Interfaces;

namespace Supermarket.Core.Services.EntityServices
{
    public class CategoryService : CrudService<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository) : base(repository)
        {
        }
    }
}
