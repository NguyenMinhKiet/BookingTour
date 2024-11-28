using Domain.Entities;

namespace Domain.Repositories
{
    public interface IDashboardRepository
    {
        int GetCustomer();
        List<decimal> GetRevenueData();
        decimal GetTotalRevenue();
        int GetBooking();
        List<Payment> GetPaymentData();
    }
}
