using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Core.Entity
{
    public class Product : BaseEntity
    {
        [MaxLength(100)]
        public required string Name { get; set; }

        public string? Description { get; set; } = null;

        [Precision(10, 2)]
        public required decimal Price { get; set; }

        public required int StockLevel { get; set; }

        public string? ImageUrl { get; set; } = null;

        [MaxLength(100)]
        public required string Sku { get; set; }

        public required int CategoryId { get; set; }
        public virtual required Category Category { get; set; }

        public virtual required ICollection<OrderDetail> OrderDetails { get; set; } = [];
    }
}
