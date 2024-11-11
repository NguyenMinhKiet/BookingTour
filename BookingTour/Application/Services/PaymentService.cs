using Application.DTOs.PaymentDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> CreateAsync(PaymentCreationDto dto)
        {
            var payment = new Payment()
            {
                PaymentID = new Guid(),
                BookingID = dto.BookingID,
                CreateAt = DateTime.Now,
                Method = dto.Method,
                Status = dto.Status

            };
            await _paymentRepository.AddAsync(payment);
            return payment;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }

        public async Task<Payment> GetById(Guid id)
        {
            return await _paymentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Guid id, PaymentUpdateDto dto)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment != null)
            {
                payment.ModifyAt = DateTime.Now;
                payment.Method = dto.Method;
                payment.Status = dto.Status;
                await _paymentRepository.UpdateAsync(payment);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            await _paymentRepository.DeleteAsync(id);
        }
    }
}
