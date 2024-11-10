using Application.DTOs.BookingDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingController (IBookingService bookingService)
        {
            _bookingService = bookingService;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookingCreationDto dto)
        {
            if(ModelState.IsValid)
            {
                await _bookingService.CreateAsync(dto);
                TempData["success"] = "Thêm thông tin booking thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thêm thông tin booking thất bại !!";
            return View();
        }

        public async Task<IActionResult> Update(Guid booking_id)
        {
            var booking = await _bookingService.GetById(booking_id);
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
            else
            {
                throw new Exception($"Không tìm thấy booking: {booking_id}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid booking_id, BookingUpdateDto dto)
        {
            var booking = await _bookingService.GetById(booking_id);
            if(booking == null)
            {
                TempData["success"] = $"Không tìm thấy booking: {booking_id}";
                return RedirectToAction("Index");
            }

            await _bookingService.UpdateAsync(booking_id, dto);
            TempData["success"] = "Chỉnh sửa thông tin booking thành công.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid booking_id)
        {
            var booking = await _bookingService.GetById(booking_id);
            if(booking == null)
            {
                throw new Exception($"Không tìm thấy booking {booking_id}");
            }
            await _bookingService.DeleteAsync(booking_id);
            TempData["success"] = $"Xóa thông tin booking {booking_id} thành công.";
            return RedirectToAction("Index");
        }
    }
}
