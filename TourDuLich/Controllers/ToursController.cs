using Microsoft.AspNetCore.Mvc;
using TourDuLich.Models;

namespace TourDuLich.Controllers
{
    public class ToursController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ToursController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTour()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTour(Tour tour)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.Add(tour);
                _context.SaveChanges();
                TempData["msg"] = "Thêm Tour thành công";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Không thể thêm Tour";
                return View();
            }
        }

        public IActionResult DisplayTours()
        {
            var tours = _context.Tour.ToList();
            return View();
        }
    }
}
