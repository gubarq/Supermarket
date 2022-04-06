using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Data.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public decimal TotalPrice { get; set; }
        public int? NumberOfProducts { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();



    }
}
