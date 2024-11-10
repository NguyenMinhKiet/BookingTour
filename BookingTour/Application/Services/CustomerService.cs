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

        public async Task<Customer> GetById(Guid id)
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
                CustomerID = new Guid(),
                FirstName = customerCreationDto.FirstName,
                LastName = customerCreationDto.LastName,
                Email = customerCreationDto.Email,
                Phone = customerCreationDto.Phone,
                Address = customerCreationDto.Address,
                AccountID = customerCreationDto.AccountID,
            };
            await _customerRepository.AddAsync(newCustomer);
            return newCustomer;
        }

        public async Task UpdateAsync(Guid customer_id, CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _customerRepository.GetByIdAsync(customer_id);
            if( customer != null)
            {
                customer.FirstName = customerUpdateDto.FirstName;
                customer.LastName = customerUpdateDto.LastName;
                customer.Email = customerUpdateDto.Email;
                customer.Phone = customerUpdateDto.Phone;
                customer.Address = customerUpdateDto.Address;

                await _customerRepository.UpdateAsync(customer);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}
