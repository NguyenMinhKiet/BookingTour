using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Booking()
            {
                return View();
            } 
    }
}
