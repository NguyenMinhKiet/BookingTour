using Application.DTOs.PaymentDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface IPaymentService
    {
        public Task<Payment> GetById(Guid id);

        public Task<IEnumerable<Payment>> GetAllAsync();

        public Task<Payment> CreateAsync(PaymentCreationDto dto);

        public Task UpdateAsync(Guid id, PaymentUpdateDto dto);

        public Task DeleteAsync(Guid id);
    }
}
