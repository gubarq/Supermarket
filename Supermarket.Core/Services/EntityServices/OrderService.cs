using Microsoft.EntityFrameworkCore;
using Supermarket.Core.Services.EntityServices.Interfaces;
using Supermarket.Database.Entities;
using Supermarket.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Services.EntityServices
{
    public class OrderService : CrudService<Order>, IOrderService
    {
        public OrderService(IRepository<Order> repository) : base(repository)
        {
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
            => await _repository.GetQuery().Include(o => o.User).ToListAsync();

        public override async Task<Order> GetByIdAsync(Guid id)
            => await _repository.GetQuery().Where(o => o.Id == id)
            .Include(o => o.Products)
            .ThenInclude(p => p.Product)
            .Include(o => o.User).FirstOrDefaultAsync();

        public async Task PlaceOrderAsync(List<OrderProduct> products, User User)
        {
            var order = new Order()
            {
                OrderDate = DateTime.UtcNow,
                Products = products,
                TotalPrice = products.Select(p => p.Quantity * p.Product.Price).Aggregate((a, b) => a + b),
                User = User
            };

            await _repository.CreateOrUpdateAsync(order);
        }
    }
}
