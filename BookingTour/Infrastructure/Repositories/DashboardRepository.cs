using Domain.Entities;
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

        public List<Payment> GetPaymentData()
        {
            return  _context.Payments
                .Include(x=>x.Booking)
                .Include(x=>x.Customer)
                .ToList();
        }

        public List<decimal> GetRevenueData()
        {
            int currentYear = DateTime.Now.Year;

            // Lấy danh sách doanh thu theo từng tháng của năm hiện tại
            var monthlyRevenue = _context.Bookings
                .Include(x => x.Payment)
                .Where(x => x.Payment.Status == true && x.Payment.CreateAt.Year == currentYear)
                .GroupBy(x => x.Payment.CreateAt.Month) // Nhóm theo tháng
                .Select(g => new
                {
                    Month = g.Key,
                    TotalRevenue = g.Sum(x => x.TotalPrice) // Tính tổng doanh thu cho mỗi tháng
                })
                .ToList();

            // Khởi tạo danh sách có đủ 12 tháng, nếu tháng nào thiếu thì gán giá trị 0
            List<decimal> revenueData = new List<decimal>();

            for (int month = 1; month <= 12; month++)
            {
                // Kiểm tra nếu có dữ liệu cho tháng này
                var monthData = monthlyRevenue.FirstOrDefault(m => m.Month == month);
                revenueData.Add(monthData?.TotalRevenue ?? 0); // Nếu không có dữ liệu cho tháng, thêm 0
            }

            return revenueData;
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
