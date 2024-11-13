
using Application.DTOs.BookingDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface IBookingService
    {
        public Task<Booking> GetById(Guid id);

        public Task<IEnumerable<Booking>> GetAllAsync();

        public Task<Booking> CreateAsync(BookingCreationDto dto);

        public Task<bool> UpdateAsync(Guid booking_id, BookingUpdateDto dto);

        public Task DeleteAsync(Guid id);

        public Task<bool> CancelBooking(Guid id);
    }
}
