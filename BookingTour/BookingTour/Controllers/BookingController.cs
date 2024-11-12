using Application.DTOs.BookingDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;
using System.Net.WebSockets;

namespace Presentation.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ITourService _tourService;
        public BookingController (IBookingService bookingService, ITourService tourService)
        {
            _bookingService = bookingService;
            _tourService = tourService; 
        }
        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingService.GetAllAsync();
            var bookingsViewModel = bookings.Select(i => new BookingViewModel
            {
                BookingID = i.BookingID,
                CustomerID = i.CustomerID,
                TourID = i.TourID,
                Adult = i.Adult,
                Child = i.Child,
                CreateAt = i.CreateAt,
                ModifyAt = i.ModifyAt,
                TotalPrice = i.TotalPrice
            }).ToList();

            return View(bookingsViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var tours = await _tourService.GetAllAsync();
            if(tours != null)
            {
                var listTour = tours.Select(tour => new TourViewModel
                {
                    TourID = tour.TourID,
                    Title = tour.Title
                }).ToList();

                ViewBag.ListTour = new SelectList(listTour, "TourID", "Title");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingCreationDto dto)
        {
            if(ModelState.IsValid)
            {
                await _bookingService.CreateAsync(dto);

                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = "Đặt Tour thành công!";

                return RedirectToAction("Index");
            }

            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Đặt Tour thất bại, hãy kiểm tra lại các thông tin!";
            return View();
        }

        public async Task<IActionResult> Update(Guid BookingID)
        {
            var booking = await _bookingService.GetById(BookingID);
            if (booking != null)
            {
                var bookingViewModel = new BookingViewModel
                {
                    BookingID = booking.BookingID,
                    CustomerID = booking.CustomerID,
                    TourID = booking.TourID,
                    Adult = booking.Adult,
                    Child = booking.Child,
                    CreateAt = booking.CreateAt,
                    ModifyAt = booking.ModifyAt,
                    TotalPrice = booking.TotalPrice
                };

                return View(bookingViewModel);
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Không thể lấy giữ liệu từ id: {BookingID}";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid BookingID, BookingUpdateDto dto)
        {
            if(ModelState.IsValid)
            {
                await _bookingService.UpdateAsync(BookingID, dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Cập nhật thông tin đặt tour thành công!";
                return RedirectToAction("Index");
            }

            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ!";
            return View();
        }

        public async Task<IActionResult> Delete(Guid BookingID)
        {
            var booking = await _bookingService.GetById(BookingID);
            if(booking == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = "Xóa thông tin đặt Tour thất bại, Không tìm thấy dữ liệu"; ;
                return RedirectToAction("Index");
            }
            await _bookingService.DeleteAsync(BookingID);

            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành công!";
            TempData["NotificationMessage"] = "Xóa thông tin đặt tour thành công";

            return RedirectToAction("Index");
        }
    }
}
