using Microsoft.AspNetCore.Identity;
using Supermarket.Database.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Database.Entities
{
    public class Cart: BaseEntity
    {
        [Required]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }
        public int? NumberOfProducts { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }



    }
}
