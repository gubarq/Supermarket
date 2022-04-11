using Supermarket.Database.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Database.Entities
{
    public class OrderProduct: BaseEntity
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
