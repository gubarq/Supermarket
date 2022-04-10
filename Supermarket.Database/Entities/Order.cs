using Microsoft.AspNetCore.Identity;
using Supermarket.Database.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Database.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Products = new();
        }

        public DateTime OrderDate { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
