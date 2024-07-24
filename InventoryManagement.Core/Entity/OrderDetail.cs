using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Core.Entity
{
    public class OrderDetail : BaseEntity
    {
        public required int Quantity { get; set; }

        [Precision(10, 2)]
        public required decimal UnitPrice { get; set; }

        public required int OrderId { get; set; }
        public virtual required Order Order { get; set; }

        public required int ProductId { get; set; }
        public virtual required Product Product { get; set; }
    }
}
