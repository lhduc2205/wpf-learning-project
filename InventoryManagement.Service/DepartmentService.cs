using InventoryManagement.Core.Entity;
using InventoryManagement.Core.Repository;
using InventoryManagement.Core.Service;

namespace InventoryManagement.Service
{
    internal class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        public ICollection<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        public ICollection<Department> GetDepartmentByParentId(int departmentId)
        {
            return _departmentRepository.GetDepartmentByParentId(departmentId);
        }

        public Department? GetDepartmentById(int departmentId)
        {
            return _departmentRepository.GetDepartmentById(departmentId);
        }

        public ICollection<Department> GetRootDepartments()
        {
            return _departmentRepository.GetRootDepartments();
        }

        public void SaveDepartment(Department department)
        {
            _departmentRepository.SaveDepartment(department);
        }
    }
}
