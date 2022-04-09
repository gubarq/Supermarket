using Supermarket.Database.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Database.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
