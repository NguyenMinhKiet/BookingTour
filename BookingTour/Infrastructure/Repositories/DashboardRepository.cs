using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        public DashboardRepository(ApplicationDbContext context) { 
            _context = context;
        }

        public int GetBooking()
        {
            return _context.Bookings.Count();
        }

        public int GetCustomer()
        {
            return _context.Customers.Count();
        }

        public List<decimal> GetRevenueData()
        {
            return _context.Bookings
                .Include(x => x.Payment)
                .Where(x => x.Payment.Status == true)
                .Select(x=>x.TotalPrice).ToList();
        }

        public decimal GetTotalRevenue()
        {
            return _context.Bookings
                .Include(x => x.Payment)
                .Where(x => x.Payment.Status == true)
                .Sum(x => x.TotalPrice);
        }
    }
}
