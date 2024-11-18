using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            var payment = new Payment
            {
                PaymentID = Guid.NewGuid(),
                BookingID = booking.BookingID,
                Status = false,
                Method = ""
                
            };

            var feedback = new Feedback
            {
                FeedbackID = Guid.NewGuid(),
                TourID = booking.TourID,
                CustomerID = booking.CustomerID,
                Comments = "",
                Rating = 5
            };

            await _context.Feedbacks.AddAsync(feedback);
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var booking = await GetByIdAsync(id);
            if( booking == null)
            {
                throw new Exception($"Booking with id {id} not found.");
            }
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(x=> x.Tour)
                .Include(x=> x.Customer)
                .ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(Guid id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
    }
}
