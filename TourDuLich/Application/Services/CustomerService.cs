using TourDuLich.Application.DTOs.CustomerDTOs;
using TourDuLich.Domain.Entities;
using TourDuLich.Domain.Services;

namespace TourDuLich.Application.Services
{
    public class CustomerService : ICustomerService
    {
        public Task DeleteCustomerAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetCustomerBookingHistoryAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> RegisterCustomerAsync(CustomerRegistrationDto customerDetails)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomerAsync(int customerId, CustomerUpdateDto updatedDetails)
        {
            throw new NotImplementedException();
        }
    }
}
