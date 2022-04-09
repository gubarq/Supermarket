using System.ComponentModel.DataAnnotations;

namespace Supermarket.Database.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
