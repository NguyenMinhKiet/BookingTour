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
                TempData["success"] = "Thêm tour mới thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thêm tour mới thất bại !!";
            return View();
        }

        // GET: /Tour/Update?{tour_id}
        public async Task<IActionResult> Update(Guid tour_id)
        {
            var i = await _tourService.GetById(tour_id);
            var tourViewModel = new TourViewModel
            {
                TourID = i.TourID,
                Title = i.Title,
                Description = i.Description,
                Price = i.Price,
                AvailableSeats = i.AvailableSeats,
                StartDate = i.StartDate,
                EndDate = i.EndDate,
            };
            return View(tourViewModel);

        }

        // POST: /Tour/Update?{tour_id}
        [HttpPost]
        public async Task<IActionResult> Update(Guid tour_id, TourUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourService.UpdateAsync(tour_id, dto);
                TempData["success"] = "Thay đổi thông tin tour thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thay đổi thông tin tour thất bại !!";
            return View();
        }

        // POST: /Tour/Delete?{tour_id}
        public async Task<IActionResult> Delete(Guid id)
        {
            await _tourService.DeleteAsync(id);
            TempData["success"] = "Xóa tour: " + id + " thành công.";
            return RedirectToAction("Index");
        }
    }
}
