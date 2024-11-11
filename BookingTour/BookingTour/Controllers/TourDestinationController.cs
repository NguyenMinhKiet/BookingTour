using Application.DTOs.TourDestinationDTOs;
using Application.Services_Interface;
using Domain.Entities;
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
        public async Task<IActionResult> Create(Guid TourID)
        {
            //var ToursSelect = new List<TourViewModel>();
            //var DestinationsSelect = new List<TourViewModel>();


            //var Tours = await _tourService.GetAllAsync();
            //foreach (var tour in Tours)
            //{
            //    var tourViewModel = new TourViewModel
            //    {
            //        TourID = tour.TourID,
            //        Title = tour.Title,
            //    };
            //    ToursSelect.Add(tourViewModel);
            //}
            //ViewBag.TourList = new SelectList(ToursSelect,"TourID","Title");

            ViewData["TourID"] = TourID; ;
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
                return RedirectToAction("Index","Tour");
            }
            TempData["error"] = "Thêm địa điểm vào tour thất bại !!";
            return View();
        }

        // GET: /TourDestination/Update?{TourID, DestinantionID)
        public async Task<IActionResult> Update(Guid TourID, Guid DestinantionID)
        {
            var tourDestination = await _tourDestinationService.GetById(TourID,DestinantionID);
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

        // POST: /TourDestination/Update?{TourID,DestinantionID}
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

        // POST: /TourDestination/Delete?{TourID,DestinantionID}
        public async Task<IActionResult> Delete(Guid TourID, Guid DestinationID)
        {
            await _tourDestinationService.DeleteAsync(TourID, DestinationID);
            TempData["success"] = $"Đã xóa thông tin địa điểm {DestinationID} trong tour {TourID} thành công.";
            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> GetDestinationsByTour(Guid TourID)
        {
            var tour = await _tourService.GetByIdAsync(TourID);
            var destinations = await _destinationService.GetByCategoryAsync(tour.Category);
            var destinationViewModels = destinations.Select(i =>
            new DestinationViewModel
            {
                DestinationID = i.DestinationID,
                Name = i.Name,
            });
            return Json(destinationViewModels);
        }
    }
}
