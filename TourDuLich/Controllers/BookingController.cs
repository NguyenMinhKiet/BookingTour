using Microsoft.AspNetCore.Mvc;

namespace TourDuLich.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
