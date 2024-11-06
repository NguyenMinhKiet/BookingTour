using Application.DTOs.BookingDTOs;
using Application.Services_Interface;
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
                tour_id = i.tour_id,
                booking_id = i.booking_id,
                customer_id = i.customer_id,
                booking_date = i.booking_date,
                num_people = i.num_people,
                total_price = i.total_price,

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

        public async Task<IActionResult> Update(int booking_id)
        {
            var booking = await _bookingService.GetById(booking_id);
            if (booking != null)
            {
                var bookingViewModel = new BookingViewModel
                {
                    booking_id = booking.booking_id,
                    tour_id = booking.tour_id,
                    customer_id = booking.customer_id,
                    booking_date = booking.booking_date,
                    total_price = booking.total_price,
                    num_people = booking.num_people,
                };

                return View(bookingViewModel);
            }
            else
            {
                throw new Exception($"Không tìm thấy booking: {booking_id}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int booking_id, BookingUpdateDto dto)
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

        public async Task<IActionResult> Delete(int booking_id)
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
