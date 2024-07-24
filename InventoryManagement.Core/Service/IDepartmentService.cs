using InventoryManagement.Core.Entity;

namespace InventoryManagement.Core.Service
{
    public interface IDepartmentService
    {
        ICollection<Department> GetAllDepartments();
        ICollection<Department> GetDepartmentByParentId(int departmentId);
        ICollection<Department> GetRootDepartments();
        Department? GetDepartmentById(int departmentId);
        void SaveDepartment(Department department);
    }
}
