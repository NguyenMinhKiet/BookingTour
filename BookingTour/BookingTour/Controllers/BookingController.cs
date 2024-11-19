using Application.DTOs.BookingDTOs;
using Application.DTOs.TourDTOs;
using Application.Services;
using Application.Services_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;

namespace Presentationx.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ITourService _tourService;
        private readonly ICustomerService _customerService;
        public BookingController(IBookingService bookingService, ITourService tourService, ICustomerService customerService)
        {
            _bookingService = bookingService;
            _tourService = tourService;
            _customerService = customerService;
        }

        [Authorize(Policy = "booking-add")]
        public async Task<IActionResult> Create(Guid TourID, Guid CustomerID)
        {
            
            var tour = await _tourService.GetByIdAsync(TourID);
            if (tour == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy Tour: {TourID}!";
                return RedirectToAction("Index");
            }


            var customer = await _customerService.GetById(CustomerID);

            var customerViewModel = new CustomerViewModel
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Phone = customer.Phone,
                Email = customer.Email,
            };


            var tourViewModel = new TourViewModel
            {
                TourID = tour.TourID,
                Title = tour.Title,
                City = tour.City,
                Description = tour.Description,
                StartDate = tour.StartDate,
                EndDate = tour.EndDate,
                Price = tour.Price,
                
            };

            var bookingConfirmViewModel = new BookingConfirmModel
            {
                CustomerData = customerViewModel,
                TourData = tourViewModel,
            };

            return View(bookingConfirmViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "booking-add")]
        public async Task<IActionResult> Create(BookingCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.CreateAsync(dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = "Đặt Tour thành công!";
                return RedirectToAction("Index","Tour");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Đặt Tour thất bại, hãy kiểm tra lại các thông tin!";
            return View();
        }
    }
}

