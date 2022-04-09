using Supermarket.Database.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Database.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
