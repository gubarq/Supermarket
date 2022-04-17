using Supermarket.Database.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Database.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Orders = new();
        }

        [Required]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Range(0, 1000)]
        public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public int Quantity { get; set; } = 0;

        [StringLength(500)]
        public string Description { get; set; }

        public virtual List<OrderProduct> Orders { get; set; }
    }
}
