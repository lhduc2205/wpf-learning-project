using InventoryManagement.Core.Entity;
using InventoryManagement.Core.Repository;
using InventoryManagement.Core.Service;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Service
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _employeeRepository = employeeRepository;
        }

        public ICollection<Employee> GetAllEmployees()
        {
            using var _scope = _serviceProvider.CreateScope();
            var employeeRepository = _scope.ServiceProvider.GetRequiredService<IEmployeeRepository>();
            return employeeRepository.GetAllEmployees();
        }

        public ICollection<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            using var _scope = _serviceProvider.CreateScope();
            var employeeRepository = _scope.ServiceProvider.GetRequiredService<IEmployeeRepository>();
            return employeeRepository.GetEmployeesByDepartmentId(departmentId);
        }

        public Employee? GetEmployeeById(int employeeId)
        {
            using var _scope = _serviceProvider.CreateScope();
            var employeeRepository = _scope.ServiceProvider.GetRequiredService<IEmployeeRepository>();
            return employeeRepository.GetEmployeeById(employeeId);
        }

        public void SaveEmployee(Employee employee)
        {
            using var _scope = _serviceProvider.CreateScope();
            var employeeRepository = _scope.ServiceProvider.GetRequiredService<IEmployeeRepository>();
            employeeRepository.SaveEmployee(employee);
        }

        public void SaveEmployee(ICollection<Employee> employees)
        {
            using var _scope = _serviceProvider.CreateScope();
            var employeeRepository = _scope.ServiceProvider.GetRequiredService<IEmployeeRepository>();
            employeeRepository.SaveEmployee(employees);
        }
    }
}
