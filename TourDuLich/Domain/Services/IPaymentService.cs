using TourDuLich.Application.DTOs.PaymentDTOs;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetPaymentsByBookingIdAsync(int bookingId);
        Task<Payment> CreatePaymentAsync(PaymentCreationDto paymentDto);
        Task UpdatePaymentAsync(int paymentId, PaymentUpdateDto paymentDto);
        Task DeletePaymentAsync(int paymentId);
    }
}
