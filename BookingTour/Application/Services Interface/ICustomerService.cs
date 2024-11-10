using Application.DTOs.CustomerDTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services_Interface
{
    public interface ICustomerService
    {
        public Task<Customer> GetById(Guid id);

        public Task<IEnumerable<Customer>> GetAllAsync();

        public Task<Customer> CreateAsync(CustomerCreationDto dto);

        public Task UpdateAsync(Guid customer_id,CustomerUpdateDto dto);

        public Task DeleteAsync(Guid id);
        

    }
}
