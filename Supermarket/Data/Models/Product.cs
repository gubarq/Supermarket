using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Data.Models
{ 
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        public Guid CategoryId { get; set; }
        
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "money")]
        [Range(0,1000)]
        public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public int Availability { get; set; } = 0;
        [StringLength(500)]
        public string Description { get; set; }
    }
}
