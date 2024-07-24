namespace InventoryManagement.Core.Entity
{
    public class Employee : BaseEntity
    {
        public required string Name { get; set; }
        public int DepartmentId { get; set; }
        public required virtual Department Department { get; set; }
    }
}
