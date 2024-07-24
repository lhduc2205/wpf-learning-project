using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Core.Entity
{
    public class Category : BaseEntity
    {
        [MaxLength(100)]
        public string? Name { get; set; }

        public string? Description { get; set; } = null;

        public virtual ICollection<Product> Products { get; set; } = [];
    }
}