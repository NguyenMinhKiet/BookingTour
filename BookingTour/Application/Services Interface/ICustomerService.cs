using Application.DTOs.CustomerDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface ICustomerService
    {
        public Task<Customer> GetById(int id);

        public Task<IEnumerable<Customer>> GetAllAsync();

        public Task<Customer> CreateAsync(CustomerCreationDto dto);

        public Task UpdateAsync(int customer_id,CustomerUpdateDto dto);

        public Task DeleteAsync(int id);

    }
}
