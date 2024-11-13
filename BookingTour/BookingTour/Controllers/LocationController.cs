using Application.Services;
using Application.Services_Interface;
using Domain.Entities.Location;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Presentation.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILocationService locationService, ILogger<LocationController> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var locationData = await _locationService.LoadAllCitysAsync();
            var cities = new List<City>();

            foreach (var i in locationData)
            {
                cities.Add(i);
            }
            // Log dữ liệu ra console
            ViewData["Cities"] = cities;
            return View(cities);
        }
    }
}
