using TourDuLich.Application.DTOs.EmployeeDTOs;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<Employee> CreateEmployeeAsync(EmployeeCreationDto employeeDto);
        Task UpdateEmployeeAsync(int employeeId, EmployeeUpdateDto employeeDto);
        Task DeleteEmployeeAsync(int employeeId);
    }
}
