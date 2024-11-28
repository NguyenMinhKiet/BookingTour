using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeStatus(Guid id, bool status)
        {
            var payment = await GetByIdAsync(id);
            if (payment != null)
            {
                payment.Status = status;
                await UpdateAsync(payment);
            }
            else
            {
                throw new Exception($"Payment with id {id} not found.");
            }
            
        }

        public async Task DeleteAsync(Guid id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if(payment is null)
            {
                throw new Exception($"Payment with id {id} not found.");
            }
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(Guid id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> GetStatus(Guid bookingID)
        {
            var booking = await _context.Bookings.FindAsync(bookingID);
            if(booking != null)
            {
                var payment =  _context.Payments.FirstOrDefault(i=>i.BookingID == bookingID);
                return payment.Status;
            }
            return false; 
        }
        public async Task<Payment> GetByBookingId(Guid bookingID)
        {
            var booking = await _context.Bookings.FindAsync(bookingID);
            if (booking != null)
            {
                var payment = _context.Payments
                    .Include(c=>c.Customer)
                    .FirstOrDefault(i => i.BookingID == bookingID);
                return payment;
            }
            return null;

        }
    }
}
