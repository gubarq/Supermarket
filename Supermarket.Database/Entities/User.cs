using Microsoft.AspNetCore.Identity;

namespace Supermarket.Database.Entities
{
    public class User: IdentityUser<Guid>
    {
        public User()
        {
            Orders = new();
        }

        public Guid? WishListId { get; set; }

        public virtual WishList WishList { get; set; }

        public virtual List<Order> Orders{ get; set; }

    }
}
