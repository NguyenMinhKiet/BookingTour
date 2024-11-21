using Application.DTOs.CustomerDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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
                CustomerID = customerCreationDto.AccountID,
                FirstName = customerCreationDto.FirstName.Trim(),
                LastName = customerCreationDto.LastName.Trim(),
                Address = customerCreationDto.Address.Trim(),
                Phone = customerCreationDto.Phone.Trim(),
                Email = customerCreationDto.Email.Trim(),
                AccountID = customerCreationDto.AccountID
            };
            await _customerRepository.AddAsync(newCustomer);
            return newCustomer;
        }

        public async Task UpdateAsync(Guid customer_id, CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _customerRepository.GetByIdAsync(customer_id);
            if( customer != null)
            {
                customer.FirstName = customerUpdateDto.FirstName.Trim();
                customer.LastName = customerUpdateDto.LastName.Trim();
                customer.Address = customerUpdateDto.Address.Trim();
                customer.Phone = customerUpdateDto.Phone.Trim();
                await _customerRepository.UpdateAsync(customer);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}