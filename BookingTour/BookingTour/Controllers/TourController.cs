using Application.DTOs.TourDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        public TourController (ITourService tourService)
        {
            _tourService = tourService;
        }

        // GET: /Tour/
        public async Task<IActionResult> Index()
        {
            var tours = await _tourService.GetAllAsync();
            var toursViewModel = tours.Select(i=> new TourViewModel
            {
                TourID = i.TourID,
                Title = i.Title,
                Description = i.Description,
                Price = i.Price,
                AvailableSeats = i.AvailableSeats,
                StartDate = i.StartDate,
                EndDate = i.EndDate,
                Category = i.Category

            }).ToList();

            return View(toursViewModel);
        }

        // GET: /Tour/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Tour/Create
        [HttpPost]
        public async Task<IActionResult> Create(TourCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourService.CreateAsync(dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Thêm Tour thành công!";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            return View();
        }
        // GET: /Tour/Update?{TourID}
        public async Task<IActionResult> Update(Guid TourID)
        {
            var i = await _tourService.GetByIdAsync(TourID);
            if(i == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy Tour ID: {TourID}";
                return RedirectToAction("Index");
            }
            var tourViewModel = new TourViewModel
            {
                TourID = i.TourID,
                Title = i.Title,
                Description = i.Description,
                Price = i.Price,
                AvailableSeats = i.AvailableSeats,
                StartDate = i.StartDate,
                EndDate = i.EndDate,
                Category = i.Category
            };
            return View(tourViewModel);

        }

        // POST: /Tour/Update?{TourID}
        [HttpPost]
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
            return View();
        }

        // POST: /Tour/Delete?{TourID}
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tourService.DeleteAsync(id);
            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành Công!";
            TempData["NotificationMessage"] = "Xóa Tour thành công!";
            return RedirectToAction("Index");
        }
    }
}
