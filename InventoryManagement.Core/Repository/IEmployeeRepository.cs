using InventoryManagement.Core.Entity;

namespace InventoryManagement.Core.Repository
{
    internal interface IEmployeeRepository
    {
        ICollection<Employee> GetAllEmployees();
        ICollection<Employee> GetEmployeesByDepartmentId(int departmentId);
        Employee? GetEmployeeById(int employeeId);
        void SaveEmployee(Employee employee);
        void SaveEmployee(ICollection<Employee> employees);
    }
}
