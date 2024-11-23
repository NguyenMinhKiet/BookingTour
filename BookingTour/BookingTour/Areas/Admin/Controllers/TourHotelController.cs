using Application.DTOs.HotelDto;
using Application.DTOs.TourHotelDto;
using Application.Services_Interface;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    public class TourHotelController : Controller
    {
        private readonly ITourHotelService _tourHotelService;
        private readonly ITourService _tourService;
        private readonly IHotelService _hotelService;
        public TourHotelController(ITourHotelService tourHotelService, ITourService tourSerice, IHotelService hotelService)
        {
            _tourHotelService = tourHotelService;
            _tourService = tourSerice;
            _hotelService = hotelService;
        }

        public async IActionResult Create(Guid TourID)
        {
            var tour = await _tourService.GetByIdAsync(TourID);
            if(tour != null)
            {
                var hotels = await _hotelService.GetAllAsync(tour.City);
                var hotelList = hotels.Select(x => new HotelDto
                {
                    HotelID = x.HotelID,
                    Name = x.Name,
                    Star = x.Star,
                    Address = x.Address
                });
                ViewBag.HotelList = hotelList;
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TourHotelDto model)
        {
            if (ModelState.IsValid)
            {
                await _tourHotelService.CreateAsync(model);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = $"Thêm khách sạn {model.Hotel.Name} vào tour {model.Tour.Title} thành công!";
                return RedirectToAction("Index", "Tour");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Thêm khách sạn thất bại!";
            return RedirectToAction("Index", "Tour");
        }

        public async Task<IActionResult> Delete(Guid TourID, Guid HotelID)
        {
            var tourHotel = await _tourHotelService.GetById(TourID, HotelID);
            if(tourHotel != null)
            {
                await _tourHotelService.DeleteAsync(TourID, HotelID);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = $"Xóa khách sạn trong tour thành công!";
                return RedirectToAction("Index", "Tour");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Xóa khách sạn thất bại!";
            return RedirectToAction("Index", "Tour");
        }
    }
}
