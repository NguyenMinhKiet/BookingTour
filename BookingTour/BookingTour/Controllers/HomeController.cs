using Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Domain.Entities;
using Newtonsoft.Json;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //String userData = HttpContext.Session.GetString("user");
            //if (userData != null)
            //{
            //    User user = JsonConvert.DeserializeObject<User>(userData);
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
