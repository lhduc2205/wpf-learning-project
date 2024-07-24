using InventoryManagement.Core.Context;
using InventoryManagement.Core.Entity;
using InventoryManagement.Core.Repository;

namespace InventoryManagement.Repository
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;

        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ICollection<Employee> GetAllEmployees()
        {
            return [.. _context.Employees];
        }

        public ICollection<Employee> GetEmployeesByDepartmentId(int parentDepartmentId)
        {
            return [.. _context.Employees.Where(e => e.DepartmentId == parentDepartmentId)];
        }

        public Employee? GetEmployeeById(int employeeId)
        {
            return _context.Employees.Find(employeeId);
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Remove(employee);
        }

        public void SaveEmployee(Employee employee)
        {
            if (_context.Employees.Any(c => c.Id == employee.Id))
            {
                _context.Employees.Update(employee);
            }
            else
            {
                _context.Employees.Add(employee);
            }
            _context.SaveChanges();
        }

        public void SaveEmployee(ICollection<Employee> employees)
        {
            foreach (Employee employee in employees)
            {

                if (_context.Employees.Any(c => c.Id == employee.Id))
                {
                    _context.Employees.Update(employee);
                }
                else
                {
                    _context.Employees.Add(employee);
                }
            }

            _context.SaveChanges();
        }
    }
}
