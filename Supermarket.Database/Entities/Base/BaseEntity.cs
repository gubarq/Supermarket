﻿using System.ComponentModel.DataAnnotations;

namespace Supermarket.Database.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
