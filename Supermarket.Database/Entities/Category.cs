using Supermarket.Database.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Database.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new();
        }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFeatured { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
