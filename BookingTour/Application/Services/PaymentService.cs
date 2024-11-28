using Application.DTOs.PaymentDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Identity.Client;

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
                PaymentID = Guid.NewGuid(),
                BookingID = dto.BookingID,
                CreateAt = DateTime.Now,
                Method = dto.Method,
                Status = dto.Status,
                Total = dto.Total,

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
                payment.Total = dto.Total;
                payment.Method = dto.Method;
                payment.Status = dto.Status;
                await _paymentRepository.UpdateAsync(payment);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            await _paymentRepository.DeleteAsync(id);
        }

        public async Task ChangeStatus(Guid PaymentID, bool status)
        {
            await _paymentRepository.ChangeStatus(PaymentID, status);
        }

        public async Task<bool> GetStatus(Guid BookingID)
        {
            return await _paymentRepository.GetStatus(BookingID);
        }

        public async Task<Payment> GetByBookingId(Guid bookingID)
        {
            return await _paymentRepository.GetByBookingId(bookingID);
        }
    }
}
