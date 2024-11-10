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
                TourID = i.TourID,
                DestinationID = i.DestinationID,
                VisitDate = i.VisitDate
            }).ToList();

            return View(tourDestinationsViewModel);
        }

        // GET: /TourDestination/Create
        public async Task<IActionResult> Create()
        {
            var tours = await _tourService.GetAllAsync();
            var toursViewModel = tours.Select(i => new TourViewModel
            {
                Title = i.Title,
                TourID = i.TourID,

            }).ToList();
            var toursSelectList = new SelectList(toursViewModel, "TourID", "Title");

            var destinations = await _destinationService.GetAllAsync();
            var destinationsViewModel = destinations.Select(i => new DestinationViewModel
            {
                DestinationID = i.DestinationID,
                Name = i.Name,

            }).ToList();
            var destinationsSelectList = new SelectList(destinationsViewModel, "DestinationID", "Name");

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
        public async Task<IActionResult> Update(Guid tour_id, Guid destination_id)
        {
            var tourDestination = await _tourDestinationService.GetById(tour_id,destination_id);
            if(tourDestination != null)
            {
                var tourDestinationViewModel = new TourDestinationViewModel
                {
                    TourID = tourDestination.TourID,
                    DestinationID = tourDestination.DestinationID,
                    VisitDate = tourDestination.VisitDate
                };
                return View(tourDestinationViewModel);
            }
            return RedirectToAction("Error", "Shared");
        }

        // POST: /TourDestination/Update?{tour_id,destination_id}
        [HttpPost]
        public async Task<IActionResult> Update(Guid TourID, Guid DestinationID, TourDestinationUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourDestinationService.UpdateAsync(TourID, DestinationID, dto);
                TempData["success"] = $"Thay đổi thời gian đến tại địa điểm {DestinationID} của tour {TourID} thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thay đổi thông tin địa điểm tour thất bại !!";
            return View();
        }

        // POST: /TourDestination/Delete?{tour_id,destination_id}
        public async Task<IActionResult> Delete(Guid tour_id, Guid destination_id)
        {
            await _tourDestinationService.DeleteAsync(tour_id, destination_id);
            TempData["success"] = $"Đã xóa thông tin địa điểm {destination_id} trong tour {tour_id} thành công.";
            return RedirectToAction("Index");
        }
    }
}
