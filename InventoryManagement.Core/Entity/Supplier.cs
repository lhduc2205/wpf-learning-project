namespace InventoryManagement.Core.Entity
{
    public class Supplier : BaseEntity
    {
        public required string Name { get; set; }

        public string? ContactName { get; set; } = null;

        public string? Phone { get; set; } = null;

        public string? Email { get; set; } = null;

        public string? Address { get; set; } = null;

        public virtual ICollection<Order> Orders { get; set; } = [];

    }
}
