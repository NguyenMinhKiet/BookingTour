using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IDashboardRepository
    {
        int GetCustomer();
        List<decimal> GetRevenueData();
        decimal GetTotalRevenue();
        int GetBooking();
    }
}
