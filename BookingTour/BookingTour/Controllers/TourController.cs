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
                tour_id = i.tour_id,
                tour_name = i.tour_name,
                description = i.description,
                start_Date = i.start_Date,
                price = i.price,
                end_Date = i.end_Date,
                availableSeats = i.availableSeats,

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
        public async Task<IActionResult> Update(int tour_id)
        {
            var tour = await _tourService.GetById(tour_id);
            var tourViewModel = new TourViewModel
            {
                tour_name = tour.tour_name,
                description = tour.description,
                start_Date = tour.start_Date,
                end_Date = tour.end_Date,
                price = tour.price,
                availableSeats = tour.availableSeats
            };
            return View(tourViewModel);

        }

        // POST: /Tour/Update?{tour_id}
        [HttpPost]
        public async Task<IActionResult> Update(int tour_id, TourUpdateDto dto)
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
        public async Task<IActionResult> Delete(int id)
        {
            await _tourService.DeleteAsync(id);
            TempData["success"] = "Xóa tour: " + id + " thành công.";
            return RedirectToAction("Index");
        }
    }
}
