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
                first_name = dto.first_name,
                last_name = dto.last_name,
                email = dto.email,
                phone = dto.phone,
                position = dto.position,
                address = dto.address,
            };
            await _employeeRepository.AddAsync(employee);
            return employee;
        }

        public async Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int customer_id, EmployeeUpdateDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(customer_id);
            if (employee != null)
            {
                employee.first_name = dto.first_name;
                employee.last_name = dto.last_name;
                employee.email = dto.email;
                employee.phone = dto.phone;
                employee.position = dto.position;
                employee.address = dto.address;

                await _employeeRepository.UpdateAsync(employee);
            }
        }
    }
}
