using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Core.Entity
{
    public class Order : BaseEntity
    {
        public required DateTime OrderDate { get; set; }

        [Precision(10, 2)]
        public required decimal TotalAmount { get; set; }

        public required int SupplierId { get; set; }
        public virtual required Supplier Supplier { get; set; }

        public virtual required ICollection<OrderDetail> OrderDetails { get; set; } = [];
    }
}
