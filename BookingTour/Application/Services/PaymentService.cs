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
                booking_id = dto.booking_id,
                payment_date = dto.payment_date,
                payment_method = dto.payment_method,
                payment_status = dto.payment_status
            };
            await _paymentRepository.AddAsync(payment);
            return payment;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }

        public async Task<Payment> GetById(int id)
        {
            return await _paymentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, PaymentUpdateDto dto)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment != null)
            {
                payment.booking_id = dto.booking_id;
                payment.payment_method = dto.payment_method;
                payment.payment_date = dto.payment_date;
                payment.payment_status = dto.payment_status;

                await _paymentRepository.UpdateAsync(payment);
            }
        }
        public async Task DeleteAsync(int id)
        {
            await _paymentRepository.DeleteAsync(id);
        }
    }
}
