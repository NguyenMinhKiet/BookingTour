using Application.DTOs.DestinationDTOs;
using Application.DTOs.TourDestinationDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Areas.Admin.Models;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Policy = "RequiredAdminOrManager")]
    [Area("Admin")]
    public class TourDestinationController : Controller
    {
        private readonly ITourDestinationService _tourDestinationService;
        private readonly ITourService _tourService;
        private readonly IDestinationService _destinationService;

        public TourDestinationController(ITourDestinationService tourDestinationService, ITourService tourService, IDestinationService destinationService)
        {
            _tourDestinationService = tourDestinationService;
            _tourService = tourService;
            _destinationService = destinationService;
        }

        // GET: /TourDestination/
        [Authorize(Policy = "tour-destination-view")]
        public async Task<IActionResult> Index(Guid TourID)
        {
            var tour = await _tourService.GetByIdAsync(TourID);

            if (tour == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy TourID: {TourID}!";
                return View();
            }
            var destinations = await _tourDestinationService.GetByTourIdAsync(TourID);

            var destinationsViewModel = destinations.Select(x => new DestinationWithVisitDateViewModel
            {
                DestinationID = x.DestinationID,
                Name = x.Destination.Name,
                Category = x.Destination.Category,
                Description = x.Destination.Description,
                City = x.Destination.City,
                Country = x.Destination.Country,
                visitDate = x.VisitDate 

            }).ToList();

            var tourDestinationViewModel = new TourDestinationViewModel
            {
                TourID = TourID,
                TourName = tour.Title,
                Destinations = destinationsViewModel
            };
            return View(tourDestinationViewModel);
        }

        // GET: /TourDestination/Create
        [Authorize(Policy = "tour-destination-add")]
        [HttpGet]
        public async Task<IActionResult> Create(Guid TourID)
        {
            var tour = await _tourService.GetByIdAsync(TourID);
            if(tour == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy TourID: {TourID}!";
                return View();
                    
            }
            TempData["TourID"] = TourID; ;

            var tourDestinationViewmodel = new TourDestinationCreationDto
            {
                TourID = TourID,
            };

            return View(tourDestinationViewmodel);
        }

        // POST: /TourDestination/Create
        [HttpPost]
        [Authorize(Policy = "tour-destination-add")]
        public async Task<IActionResult> Create(TourDestinationCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourDestinationService.CreateAsync(dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Thêm địa điểm vào Tour thành công!";
                return RedirectToAction("Index", "TourDestination", new {TourID = dto.TourID});
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            return View();
        }

        // GET: /TourDestination/Update?{TourID, DestinantionID)
        [Authorize(Policy = "tour-destination-update")]
        [HttpGet]
        public async Task<IActionResult> Update(Guid TourID, Guid DestinationID)
        {
            var tourDestination = await _tourDestinationService.GetById(TourID, DestinationID);
            if (tourDestination != null)
            {
                var tourDestinationViewModel = new TourDestinationUpdateViewModel
                {
                    TourID = tourDestination.TourID,
                    DestinationID = tourDestination.DestinationID,
                    VisitDate = tourDestination.VisitDate
                };
                return View(tourDestinationViewModel);
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Không tìm thấy TourID: {TourID} và DestinationID: {DestinationID}";
            return RedirectToAction("Index", new { TourID = TourID });
        }

        // POST: /TourDestination/Update?{TourID,DestinantionID}
        [HttpPost]
        [Authorize(Policy = "tour-destination-update")]
        public async Task<IActionResult> Update(Guid TourID, Guid DestinationID, TourDestinationUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourDestinationService.UpdateAsync(TourID, DestinationID, dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Cập nhật thông tin thời gian đến địa điểm tour thành công!";
                return RedirectToAction("Index" , new {TourID = TourID});
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            return View();
        }

        // POST: /TourDestination/Delete?{TourID,DestinantionID}
        [Authorize(Policy = "tour-destination-delete")]
        public async Task<IActionResult> Delete(Guid TourID, Guid DestinationID)
        {
            await _tourDestinationService.DeleteAsync(TourID, DestinationID);
            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành Công!";
            TempData["NotificationMessage"] = "Xóa địa điểm trong tour thành công!";
            return RedirectToAction("Index", new { TourID = TourID });
        }


        [HttpGet]
        public async Task<IActionResult> GetDestinationsByTour(Guid TourID)
        {
            var tour = await _tourService.GetByIdAsync(TourID);
            Console.WriteLine(tour.City);

            var destinations = await _destinationService.GetByCityAsync(tour.City);
            var destinationViewModels = destinations.Select(i =>
            new Models.DestinationViewModel
            {
                DestinationID = i.DestinationID,
                Name = i.Name,
            });
            return Json(destinationViewModels);
        }

        
    }
}