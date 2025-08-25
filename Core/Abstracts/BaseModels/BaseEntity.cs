using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Abstracts.BaseModels
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
        public bool Deleted { get; set; } = false;
    }
}
