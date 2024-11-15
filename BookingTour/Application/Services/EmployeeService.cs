using Application.DTOs.CustomerDTOs;
using Application.DTOs.EmployeeDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> CreateAsync(EmployeeCreationDto dto)
        {
            var employee = new Employee()
            {
                EmployeeID = new Guid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Position = dto.Position,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                AccountID = dto.AccountID,
            };
            await _employeeRepository.AddAsync(employee);
            return employee;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetById(Guid id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<String> GetEmployeeNameById(Guid id)
        {
            return await _employeeRepository.GetNameByIdAsync(id);
        }

        public async Task<String> GetEmployeePositionById(Guid id)
        {
            return await _employeeRepository.GetPositionByIdAsync(id);
        }

        public async Task UpdateAsync(Guid customer_id, EmployeeUpdateDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(customer_id);
            if (employee != null)
            {
                employee.FirstName = dto.FirstName;
                employee.LastName = dto.LastName;
                employee.Position = dto.Position;
                employee.Address = dto.Address;

                await _employeeRepository.UpdateAsync(employee);
            }
        }
    }
}
