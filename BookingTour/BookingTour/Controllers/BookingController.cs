using Application.DTOs.BookingDTOs;
using Application.DTOs.TourDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentationx.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ITourService _tourService;
        private readonly ICustomerService _customerService;
        private readonly IPaymentService _paymentService;
        public BookingController(IBookingService bookingService, ITourService tourService, ICustomerService customerService,  IPaymentService paymentService)
        {
            _bookingService = bookingService;
            _tourService = tourService;
            _customerService = customerService;
            _paymentService = paymentService;
        }

        [Authorize(Policy = "booking-add")]
        public async Task<IActionResult> Create(Guid TourID, Guid UserID)
        {
            
            var tour = await _tourService.GetByIdAsync(TourID);
            if (tour == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy Tour: {TourID}!";
                return RedirectToAction("Index");
            }


            var customer = await _customerService.GetByUserID(UserID);

            var customerViewModel = new CustomerViewModel
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Phone = customer.Phone,
                Email = customer.Email,
                AccountID = customer.AccountID,
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
                AvailableSeats = tour.AvailableSeats
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
        public async Task<IActionResult> Create(Guid TourID, Guid CustomerID, BookingCreationDto dto)
        {
            if (ModelState.IsValid)
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
                    AccountID = customer.AccountID
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
                    AvailableSeats = tour.AvailableSeats
                };

                var bookingConfirmViewModel = new BookingConfirmModel
                {
                    CustomerData = customerViewModel,
                    TourData = tourViewModel,
                };

                var result = await _bookingService.CreateAsync(dto);
                if (result)
                {
                    TempData["NotificationType"] = "success";
                    TempData["NotificationTitle"] = "Thành công!";
                    TempData["NotificationMessage"] = "Đặt Tour thành công!";
                    return RedirectToAction("Index", "Tour");
                }
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = "Đặt Tour thất bại, Số lượng khách vượt quá số vé còn lại!";
                return RedirectToAction("Details", "Tour", new { TourID});
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Đặt Tour thất bại, hãy kiểm tra lại các thông tin!";
            return RedirectToAction("Details", "Tour", new { TourID });
        }

        public async Task<IActionResult> History(Guid UserID)
        {
            var bookings = await _bookingService.GetByCustomerID(UserID);
            var bookingsViewModel = new List<BookingViewModel>();
            foreach (var i in bookings)
            {
                var payment = await _paymentService.GetByBookingId(i.BookingID);
                ViewData[$"Status_{i.BookingID}"] = payment.Status;

                var customer = await _customerService.GetById(i.CustomerID);
                var tour = await _tourService.GetByIdAsync(i.TourID);
                var bookingViewModel = new BookingViewModel
                {
                    BookingID = i.BookingID,
                    CustomerID = i.CustomerID,
                    TourID = i.TourID,
                    Adult = i.Adult,
                    Child = i.Child,
                    CreateAt = i.CreateAt,
                    ModifyAt = i.ModifyAt,
                    TotalPrice = i.TotalPrice,
                    Customer = customer,
                    Tour = tour,
                    Status = payment.Status
                };
                bookingsViewModel.Add(bookingViewModel);
            }
            return View(bookingsViewModel);
        }
    }
}

