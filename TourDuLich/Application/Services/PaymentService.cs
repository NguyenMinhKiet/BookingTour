using TourDuLich.Application.DTOs.PaymentDTOs;
using TourDuLich.Domain.Entities;
using TourDuLich.Domain.Services;

namespace TourDuLich.Application.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<Payment> CreatePaymentAsync(PaymentCreationDto paymentDto)
        {
            throw new NotImplementedException();
        }

        public Task DeletePaymentAsync(int paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetPaymentsByBookingIdAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePaymentAsync(int paymentId, PaymentUpdateDto paymentDto)
        {
            throw new NotImplementedException();
        }
    }
}
