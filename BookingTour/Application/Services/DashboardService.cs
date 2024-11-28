using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public int GetBooking()
        {
            var result = _dashboardRepository.GetBooking();
            return result;  // Nếu result là null, trả về 0
        }

        public int GetCustomer()
        {
            var result = _dashboardRepository.GetCustomer();
            return result;  // Nếu result là null, trả về 0
        }

        public List<Payment> GetPaymentData()
        {
            return _dashboardRepository.GetPaymentData() ?? new List<Payment>(); // Trả về danh sách rỗng nếu null
        }

        public List<decimal> GetRevenueData()
        {
            var result = _dashboardRepository.GetRevenueData();
            return result ?? new List<decimal>(); // Trả về danh sách rỗng nếu null
        }

        public decimal GetTotalRevenue()
        {
            var result = _dashboardRepository.GetTotalRevenue();
            return result;
        }
    }
}
