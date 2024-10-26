using TourDuLich.Application.DTOs.BookingDTOs;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Services
{
    public interface IBookingService
    {
        Task<Booking> CreateBookingAsync(BookingCreationDto bookingDto);
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task UpdateBookingAsync(int bookingId, BookingUpdateDto bookingDto);
        Task DeleteBookingAsync(int bookingId);
    }
}
