using Microsoft.AspNetCore.Identity;
using Supermarket.Database.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Database.Entities
{
    public class WishList : BaseEntity
    {
        [Required]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public ICollection<Product> Products { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
