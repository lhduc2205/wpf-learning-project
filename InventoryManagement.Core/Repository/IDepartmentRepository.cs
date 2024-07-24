using InventoryManagement.Core.Entity;

namespace InventoryManagement.Core.Repository
{
    internal interface IDepartmentRepository
    {
        ICollection<Department> GetDepartmentByParentId(int parentDepartmentId);
        ICollection<Department> GetAllDepartments();
        ICollection<Department> GetRootDepartments();
        Department? GetDepartmentById(int departmentId);
        void DeleteDepartment(Department department);
        void SaveDepartment(Department department);
    }
}
