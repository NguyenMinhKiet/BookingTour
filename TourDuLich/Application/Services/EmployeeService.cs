using TourDuLich.Application.DTOs.EmployeeDTOs;
using TourDuLich.Domain.Entities;
using TourDuLich.Domain.Services;

namespace TourDuLich.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Task<Employee> CreateEmployeeAsync(EmployeeCreationDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeAsync(int employeeId, EmployeeUpdateDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
