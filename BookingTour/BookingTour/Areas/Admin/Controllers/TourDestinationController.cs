using Application.DTOs.TourDestinationDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Admin.Models;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
        [Authorize(Policy = "tour-destination-add")]
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
        [Authorize(Policy = "tour-destination-add")]
        public async Task<IActionResult> Create(TourDestinationCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourDestinationService.CreateAsync(dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Thêm địa điểm vào Tour thành công!";
                return RedirectToAction("Index", "Tour");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            // Lấy tất cả lỗi từ ModelState và thêm chúng vào TempData để hiển thị
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
            return View();
        }

        // GET: /TourDestination/Update?{TourID, DestinantionID)
        [Authorize(Policy = "tour-destination-update")]
        public async Task<IActionResult> Update(Guid TourID, Guid DestinantionID)
        {
            var tourDestination = await _tourDestinationService.GetById(TourID, DestinantionID);
            if (tourDestination != null)
            {
                var tourDestinationViewModel = new TourDestinationViewModel
                {
                    TourID = tourDestination.TourID,
                    DestinationID = tourDestination.DestinationID,
                    VisitDate = tourDestination.VisitDate
                };
                return View(tourDestinationViewModel);
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Không tìm thấy TourID: {TourID} và DestinationID: {DestinantionID}";
            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
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