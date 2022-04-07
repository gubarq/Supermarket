using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Data.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public DateTime OrderDate { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }
    }
}
