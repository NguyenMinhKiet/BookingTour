
using Application.DTOs.BookingDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface IBookingService
    {
        public Task<Booking> GetById(int id);

        public Task<IEnumerable<Booking>> GetAllAsync();

        public Task<Booking> CreateAsync(BookingCreationDto dto);

        public Task UpdateAsync(int booking_id, BookingUpdateDto dto);

        public Task DeleteAsync(int id);
    }
}
