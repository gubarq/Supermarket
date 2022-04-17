using Supermarket.Database.Entities;

namespace Supermarket.Core.Services.EntityServices.Interfaces
{
    public interface IOrderService : ICrudService<Order>
    {
        Task PlaceOrderAsync(List<OrderProduct> products);
    }
}
