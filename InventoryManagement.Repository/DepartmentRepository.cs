using InventoryManagement.Core.Context;
using InventoryManagement.Core.Entity;
using InventoryManagement.Core.Repository;

namespace InventoryManagement.Repository
{
    internal class DepartmentRepository(ApplicationContext context) : IDepartmentRepository
    {
        private readonly ApplicationContext _context = context;

        public ICollection<Department> GetAllDepartments()
        {
            return [.. _context.Departments];
        }

        public ICollection<Department> GetDepartmentByParentId(int parentDepartmentId)
        {
            return [.. _context.Departments.Where(d => d.ParentDepartmentId == parentDepartmentId)];
        }

        public Department? GetDepartmentById(int departmentId)
        {
            return _context.Departments.Find(departmentId);
        }

        public ICollection<Department> GetRootDepartments()
        {
            return [.. _context.Departments.Where(d => d.ParentDepartmentId == null)];
        }

        public void DeleteDepartment(Department department)
        {
            _context.Remove(department);
        }

        public void SaveDepartment(Department department)
        {
            if (_context.Departments.Any(c => c.Id == department.Id))
            {
                _context.Departments.Update(department);
            }
            else
            {
                _context.Departments.Add(department);
            }
            _context.SaveChanges();
        }
    }
}
