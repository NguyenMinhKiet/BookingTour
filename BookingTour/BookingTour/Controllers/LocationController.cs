using Application.Services;
using Domain.Entities.Location;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Presentation.Controllers
{
    public class LocationController : Controller
    {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            var locationData = await _locationService.LoadLocationDataAsync("Hà Nội");
            // Log dữ liệu ra console
            
            return View(locationData);
        }
    }
}
