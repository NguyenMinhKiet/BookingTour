using Application.DTOs.CustomerDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetById(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> CreateAsync(CustomerCreationDto customerCreationDto)
        {
            var newCustomer = new Customer()
            {
                first_name = customerCreationDto.first_name,
                last_name = customerCreationDto.last_name,
                email = customerCreationDto.email,
                phone = customerCreationDto.phone,
                address = customerCreationDto.address,
            };
            await _customerRepository.AddAsync(newCustomer);
            return newCustomer;
        }

        public async Task UpdateAsync(int customer_id, CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _customerRepository.GetByIdAsync(customer_id);
            if( customer != null)
            {
                customer.first_name = customerUpdateDto.first_name;
                customer.last_name = customerUpdateDto.last_name;
                customer.email = customerUpdateDto.email;
                customer.phone = customerUpdateDto.phone;
                customer.address = customerUpdateDto.address;

                await _customerRepository.UpdateAsync(customer);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}
