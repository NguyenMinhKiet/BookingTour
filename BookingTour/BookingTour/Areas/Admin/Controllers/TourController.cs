using Application.DTOs.LocationDto;
using Application.DTOs.TourDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Policy = "RequiredAdminOrManager")]
    [Area("Admin")]
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ILocationService _locationService;
        public TourController(ITourService tourService, ILocationService locationService)
        {
            _tourService = tourService;
            _locationService = locationService;
        }

        // GET: /Tour/
        [Authorize(Policy = "tour-view")]
        public async Task<IActionResult> Index()
        {
            var tours = await _tourService.GetAllAsync();
            var toursViewModel = tours.Select(i => new TourViewModel
            {
                TourID = i.TourID,
                Title = i.Title,
                Description = i.Description,
                Price = i.Price,
                AvailableSeats = i.AvailableSeats,
                StartDate = i.StartDate,
                EndDate = i.EndDate,
                Category = i.Category,
                City = i.City,
                Image = i.Image,

            }).ToList();

            return View(toursViewModel);
        }

        // GET: /Tour/Create
        [Authorize(Policy = "tour-add")]
        public async Task<IActionResult> CreateAsync()
        {
            var listCity = await _locationService.LoadAllCitysAsync();
            var listCityViewModel = listCity.Select(e => new CityViewModel
            {
                Name = e.Name,
            }).ToList();

            ViewData["ListCity"] = listCityViewModel;
            return View();
        }

        // POST: /Tour/Create
        [HttpPost]
        [Authorize(Policy = "tour-add")]
        public async Task<IActionResult> CreateAsync(TourCreationDto model)
        {
            if (ModelState.IsValid)
            {
                await _tourService.CreateAsync(model);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Thêm Tour thành công!";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            var listCity = await _locationService.LoadAllCitysAsync();
            var listCityViewModel = listCity.Select(e => new CityViewModel
            {
                Name = e.Name,
            }).ToList();

            ViewData["ListCity"] = listCityViewModel;
            return View(model);
        }
        // GET: /Tour/Update?{TourID}
        [Authorize(Policy = "tour-update")]
        public async Task<IActionResult> Update(Guid TourID)
        {
            var i = await _tourService.GetByIdAsync(TourID);
            if (i == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy Tour ID: {TourID}";
                return RedirectToAction("Index");
            }
            var tourViewModel = new TourUpdateDto
            {
                TourID = i.TourID,
                Title = i.Title,
                Description = i.Description,
                Price = i.Price,
                AvailableSeats = i.AvailableSeats,
                StartDate = i.StartDate,
                EndDate = i.EndDate,
                Category = i.Category,
                City = i.City,
                Image = i.Image,
                
            };

            var listCity = await _locationService.LoadAllCitysAsync();
            var listCityViewModel = listCity.Select(e => new CityViewModel
            {
                Name = e.Name,
            }).ToList();

            ViewData["ListCity"] = listCityViewModel;
            return View(tourViewModel);

        }

        // POST: /Tour/Update?{TourID}
        [HttpPost]
        [Authorize(Policy = "tour-update")]
        public async Task<IActionResult> Update(Guid TourID, TourUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourService.UpdateAsync(TourID, dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Cập nhật thông tin Tour thành công!";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            var listCity = await _locationService.LoadAllCitysAsync();
            var listCityViewModel = listCity.Select(e => new CityViewModel
            {
                Name = e.Name,
            }).ToList();

            ViewData["ListCity"] = listCityViewModel;
            return View(dto);
        }

        // POST: /Tour/Delete?{TourID}
        [Authorize(Policy = "tour-delete")]
        public async Task<IActionResult> Delete(Guid TourID)
        {
            await _tourService.DeleteAsync(TourID);
            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành Công!";
            TempData["NotificationMessage"] = "Xóa Tour thành công!";
            return RedirectToAction("Index");
        }
    }
}