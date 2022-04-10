using Microsoft.AspNetCore.Identity;
using Supermarket.Database.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Database.Entities
{
    public class WishList : BaseEntity
    {
        public WishList()
        {
            Products = new();
        }

        [Required]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
