using Application.DTOs.TourDestinationDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class TourDestinationController : Controller
    {
        private readonly ITourDestinationService _tourDestinationService;
        private readonly ITourService _tourService;
        private readonly IDestinationService _destinationService;
        
        public TourDestinationController (ITourDestinationService tourDestinationService, ITourService tourService, IDestinationService destinationService)
        {
            _tourDestinationService = tourDestinationService;
            _tourService = tourService;
            _destinationService = destinationService;
        }

        // GET: /TourDestination/
        public async Task<IActionResult> Index()
        {
            var tourDestinations = await _tourDestinationService.GetAllAsync();
            var tourDestinationsViewModel = tourDestinations.Select(i => new TourDestinationViewModel
            {
                tour_id = i.tour_id,
                destination_id = i.destination_id,
                visit_date = i.visit_date
            }).ToList();

            return View(tourDestinationsViewModel);
        }

        // GET: /TourDestination/Create
        public async Task<IActionResult> Create()
        {
            var tours = await _tourService.GetAllAsync();
            var toursViewModel = tours.Select(i => new TourViewModel
            {
                tour_name = i.tour_name,
                tour_id = i.tour_id,

            }).ToList();
            var toursSelectList = new SelectList(toursViewModel, "tour_id", "tour_name");

            var destinations = await _destinationService.GetAllAsync();
            var destinationsViewModel = destinations.Select(i => new DestinationViewModel
            {
                destination_id = i.destination_id,
                destination_name = i.destination_name,

            }).ToList();
            var destinationsSelectList = new SelectList(destinationsViewModel, "destination_id", "destination_name");

            ViewBag.TourList = toursSelectList;
            ViewBag.DestinationList = destinationsSelectList;

            return View();
        }

        // POST: /TourDestination/Create
        [HttpPost]
        public async Task<IActionResult> Create(TourDestinationCreationDto dto)
        {
            


            if (ModelState.IsValid)
            {
                await _tourDestinationService.CreateAsync(dto);
                TempData["success"] = "Thêm địa điểm vào tour thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thêm địa điểm vào tour thất bại !!";
            return View();
        }

        // GET: /TourDestination/Update?{tour_id, destination_id)
        public async Task<IActionResult> Update(int tour_id, int destination_id)
        {
            var tourDestination = await _tourDestinationService.GetById(tour_id,destination_id);
            if(tourDestination != null)
            {
                var tourDestinationViewModel = new TourDestinationViewModel
                {
                    tour_id = tourDestination.tour_id,
                    destination_id = tourDestination.destination_id,
                    visit_date = tourDestination.visit_date
                };
                return View(tourDestinationViewModel);
            }
            return RedirectToAction("Error", "Shared");
        }

        // POST: /TourDestination/Update?{tour_id,destination_id}
        [HttpPost]
        public async Task<IActionResult> Update(int tour_id, int destination_id, TourDestinationUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourDestinationService.UpdateAsync(tour_id, destination_id, dto);
                TempData["success"] = $"Thay đổi thời gian đến tại địa điểm {destination_id} của tour {tour_id} thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thay đổi thông tin địa điểm tour thất bại !!";
            return View();
        }

        // POST: /TourDestination/Delete?{tour_id,destination_id}
        public async Task<IActionResult> Delete(int tour_id, int destination_id)
        {
            await _tourDestinationService.DeleteAsync(tour_id, destination_id);
            TempData["success"] = $"Đã xóa thông tin địa điểm {destination_id} trong tour {tour_id} thành công.";
            return RedirectToAction("Index");
        }
    }
}
