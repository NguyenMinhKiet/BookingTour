using Application.DTOs.DestinationDTOs;
using Application.DTOs.TourDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using X.PagedList.Extensions;
namespace Presentation.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ILocationService _locationService;
        private readonly UserManager<Account> _userManager;
        private readonly ICustomerService _customerService;
        
        public TourController(ITourService tourService, ILocationService locationService, UserManager<Account> userManager, ICustomerService customerService)
        {
            _tourService = tourService;
            _locationService = locationService;
            _userManager = userManager;
            _customerService = customerService;
        }

        // GET: /Tour/
        [Authorize(Policy = "tour-view")]
        public async Task<IActionResult> Index(int? page, int? pageSize,decimal? from, decimal? to, string? sortBy,string searchTerm)
        {
            if(page == null || page < 1)
            {
                page = 1;
            }
            if (pageSize == null || pageSize < 1)
            {
                pageSize = 6;
            }


            var tours = await _tourService.GetAllNewAsync(searchTerm, from, to, sortBy);
            var toursViewModel = tours.Select(x => new TourCustomerView
            {
                Title = x.Title,
                TourID = x.TourID,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Price = x.Price,
                Category = x.Category,
                City = x.City,
                AvailableSeats = x.AvailableSeats
            }).ToList();

            var onPageOfTours = toursViewModel.ToPagedList((int)page, (int)pageSize);
            ViewBag.OnePageOfProducts = onPageOfTours;
            ViewBag.itemCount = tours.Count();
            return View(onPageOfTours);
        }

        [HttpPost]
        public async Task<IActionResult> GetToursByCategory(List<string> categories)
        {
            try
            {
                var tours = await _tourService.GetToursByCategoriesAsync(categories); // Đảm bảo bạn đợi kết quả từ DB
                return Json(new { success = true, data = tours });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> Details(Guid TourID)
        {
            
            var tour = await _tourService.GetByIdAsync(TourID);
            if (tour == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy Tour: {TourID}!";
                return RedirectToAction("Index");
            }

            var destinations = await _tourService.GetDestinations(tour.TourID);
            var destinationsViewModel = destinations.Select(d => new DestinationWithVisitDateViewModel
            {
                DestinationID = d.DestinationID,
                Name = d.Destination.Name,
                Description = d.Destination.Description,
                Country = d.Destination.Country,
                Category = d.Destination.Category,
                City = d.Destination.City,
                visitDate = d.VisitDate,
            }).ToList();

            var tourBookings = await _tourService.GetAllByName(tour.Title);
            var tourBookingViewModel = tourBookings.Select(x => new TourViewModel
            {
                Title = x.Title,
                TourID = x.TourID,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Price = x.Price,
                Category = x.Category,
                City = x.City,
                AvailableSeats = x.AvailableSeats
            }).ToList();

            var anotherTour = await _tourService.GetAllWithOut(tour.Title);
            var anotherTourViewModel = tourBookings.Select(x => new TourViewModel
            {
                Title = x.Title,
                TourID = x.TourID,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Price = x.Price,
                Category = x.Category,
                City = x.City,
                AvailableSeats = x.AvailableSeats
            }).ToList();

            var customerId =  HttpContext.Session.GetString("UserID");
            if(customerId == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Vui lòng đăng nhập";
                return RedirectToAction("Login","Account");
            }
            var tourDetailViewModel = new TourDetailModel
            {
                TourID = tour.TourID,
                TourName = tour.Title,
                City = tour.City,
                Description = tour.Description,
                StartDate = tour.StartDate,
                EndDate = tour.EndDate,
                CustomerID = Guid.Parse(customerId),
                Destinations = destinationsViewModel,
                TourBookings = tourBookingViewModel,
                AnotherTour = anotherTourViewModel,
            };


            return View(tourDetailViewModel);
        }
    }
}