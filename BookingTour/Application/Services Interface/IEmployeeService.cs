using Application.DTOs.EmployeeDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface IEmployeeService
    {
        public Task<Employee> GetById(Guid id);

        public Task<IEnumerable<Employee>> GetAllAsync();

        public Task<Employee> CreateAsync(EmployeeCreationDto dto);

        public Task UpdateAsync(Guid customer_id, EmployeeUpdateDto dto);

        public Task DeleteAsync(Guid id);

        public Task<String> GetEmployeeNameById(Guid id);
        public Task<String> GetEmployeePositionById(Guid id);
    }
}
