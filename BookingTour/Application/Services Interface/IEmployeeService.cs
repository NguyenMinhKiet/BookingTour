using Application.DTOs.EmployeeDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface IEmployeeService
    {
        public Task<Employee> GetById(int id);

        public Task<IEnumerable<Employee>> GetAllAsync();

        public Task<Employee> CreateAsync(EmployeeCreationDto dto);

        public Task UpdateAsync(int customer_id, EmployeeUpdateDto dto);

        public Task DeleteAsync(int id);
    }
}
