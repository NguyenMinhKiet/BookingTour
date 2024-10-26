using TourDuLich.Application.DTOs.BookingDTOs;
using TourDuLich.Domain.Entities;
using TourDuLich.Domain.Services;

namespace TourDuLich.Application.Services
{
    public class BookingService : IBookingService
    {
        public Task<Booking> CreateBookingAsync(BookingCreationDto bookingDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookingAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookingAsync(int bookingId, BookingUpdateDto bookingDto)
        {
            throw new NotImplementedException();
        }
    }
}
