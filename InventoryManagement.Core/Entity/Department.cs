namespace InventoryManagement.Core.Entity
{
    public class Department : BaseEntity
    {
        public required string Name { get; set; }

        public int? ParentDepartmentId { get; set; }
        public virtual Department? ParentDepartment { get; set; }
        public virtual ICollection<Department> ChildrenDepartments { get; set; } = [];

        public virtual ICollection<Employee> Employees { get; set; } = [];
    }
}
