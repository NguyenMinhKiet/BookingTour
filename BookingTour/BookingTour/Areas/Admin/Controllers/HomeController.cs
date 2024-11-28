using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Policy = "RequiredAdminOrManager")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public HomeController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            ViewBag.RevenueData = _dashboardService.GetRevenueData();
            ViewBag.NumCustomer = _dashboardService.GetCustomer();
            ViewBag.NumBooking = _dashboardService.GetBooking();
            ViewBag.NumTotalRevenue = _dashboardService.GetTotalRevenue();
            ViewBag.PaymentData = _dashboardService.GetPaymentData() ?? new List<Payment>();
            return View();
        }
        
    }
}