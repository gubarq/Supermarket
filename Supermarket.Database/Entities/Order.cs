using Microsoft.AspNetCore.Identity;
using Supermarket.Database.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Database.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
