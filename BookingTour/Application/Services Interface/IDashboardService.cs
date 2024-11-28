
namespace Application.Services_Interface
{
    public interface IDashboardService
    {
        int GetCustomer();
        List<decimal> GetRevenueData();
        decimal GetTotalRevenue();
        int GetBooking();
    }
}
