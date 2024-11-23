using Application.DTOs.HotelDto;
using Application.DTOs.LocationDto;
using Application.Services_Interface;
using Infrastructure.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "RequiredAdminOrManager")]
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly ILocationService _locationService;
        public HotelController(IHotelService hotelService, ILocationService locationService)
        {
            _hotelService = hotelService;
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            var hotels = await _hotelService.GetAllAsync("");
            var hotelModel = hotels.Select(x => new HotelDto
            {
                HotelID = x.HotelID,
                Name = x.Name,
                Address = x.Address,
                Star = x.Star,
                City = x.City
            }).ToList();
            return View(hotelModel);
        }

        public async Task<ActionResult> Create()
        {
            var listCity = await _locationService.LoadAllCitysAsync();
            var listCityViewModel = listCity.Select(e => new CityViewModel
            {
                Name = NORMALIZE.NormalizeCity(e.Name),
            }).ToList();

            ViewBag.ListCity = listCityViewModel;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HotelDto model)
        {
            if (ModelState.IsValid)
            {
                await _hotelService.CreateAsync(model);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = "Thêm khách sạn thành công";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu không hợp lệ";
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid HotelID)
        {
            var hotel = await _hotelService.GetByIdAsync(HotelID);
            var hotelModel = new HotelDto
            {
                HotelID = hotel.HotelID,
                Name = hotel.Name,
                Star = hotel.Star,
                Address = hotel.Address,
                City = hotel.City,
            };
            return View(hotelModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HotelDto model)
        {
            if (ModelState.IsValid)
            {
                await _hotelService.UpdateAsync(model);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = "Cập nhật thông tin khách sạn thành công";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu không hợp lệ";
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid HotelID)
        {
            var hotel = await _hotelService.GetByIdAsync(HotelID);
            if(hotel != null)
            {
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = $"Xóa khách sạn {hotel.Name} thành công";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Không tìm thấy khách sạn";
            return RedirectToAction("Index");
        }
    }
}
