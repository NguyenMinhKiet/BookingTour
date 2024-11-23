using Application.DTOs.HotelDto;
using Application.DTOs.LocationDto;
using Application.Services_Interface;
using Infrastructure.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                StarRating   = x.StarRating,
                SelectedCity = x.City,
                SelectedDistrict = x.District,
                SelectedWard = x.Ward,
                
            }).ToList();
            return View(hotelModel);
        }

        public async Task<ActionResult> Create()
        {
            var listCity = await _locationService.LoadAllCitysAsync();

            var viewModel = new HotelDto
            {
                Cities = listCity.Select(c => new SelectListItem
                {
                    Value = c.Code,
                    Text = c.Name
                }).ToList()
            };
            return View(viewModel);
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
                StarRating = hotel.StarRating,
                Address = hotel.Address,
                SelectedCity = hotel.City,
                SelectedDistrict = hotel.District,
                SelectedWard = hotel.Ward,
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

        [HttpGet]
        public async Task<IActionResult> GetDistricts(string cityCode)
        {
            var cities = await _locationService.LoadAllCitysAsync();
            var city = cities.FirstOrDefault(c => c.Code == cityCode);

            if (city == null)
                return NotFound();

            var districts = city.District.Select(d => new SelectListItem
            {
                Value = d.Name,
                Text = $"{d.Pre} {d.Name}"
            }).ToList();

            return Json(districts);
        }


        [HttpGet]
        public async Task<IActionResult> GetWards(string cityCode, string districtName)
        {
            var cities = await _locationService.LoadAllCitysAsync();
            var city = cities.FirstOrDefault(c => c.Code == cityCode);
            if (city == null)
                return NotFound();

            var district = city.District.FirstOrDefault(d => d.Name == districtName);
            if (district == null)
                return NotFound();

            var wards = district.Ward.Select(w => new SelectListItem
            {
                Value = w.Name,
                Text = $"{w.Pre} {w.Name}"
            }).ToList();

            return Json(wards);
        }
    }
}
