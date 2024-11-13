using Application.DTOs.DestinationDTOs;
using Application.Services_Interface;
using Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly ILocationService _locationService;
        private readonly ILogger<DestinationController> _logger;

        public DestinationController(IDestinationService destinationService, ILocationService locationService, ILogger<DestinationController> logger)
        {
            _destinationService = destinationService;
            _locationService = locationService;
            _logger = logger;
        }

        // GET: /Destination/
        public async Task<IActionResult> Index()
        {
            var destiations = await _destinationService.GetAllAsync();
            var destinationsViewModel = destiations.Select(i => new DestinationViewModel
            {
                DestinationID = i.DestinationID,
                Name = i.Name,
                Description = i.Description,
                City = i.City,
                Country = i.Country,
                Category = i.Category,
            }).ToList();

            return View(destinationsViewModel);
        }

        // GET: /Destination/Create
        public async Task<IActionResult> Create()
        {
            var listCity = await _locationService.LoadAllCitysAsync();
            _logger.LogInformation("Data: {data}", listCity[0]);
            return View();
        }

        // POST: /Destination/Create
        [HttpPost]
        public async Task<IActionResult> Create(DestinationCreationDto destination)
        {
            if (ModelState.IsValid)
            {
                await _destinationService.CreateAsync(destination);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = "Thêm địa điểm thành công";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ!";
            return RedirectToAction("Index");
        }


        // GET: /Destination/Update?{DestinationID}
        public async Task<IActionResult> Update(Guid DestinationID)
        {
            var destination = await _destinationService.GetById(DestinationID);

            if (destination == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy dữ liệu địa điểm id: {DestinationID}";
                return RedirectToAction("Index");
            }

            var destinationViewModel = new DestinationViewModel
            {
                DestinationID = destination.DestinationID,
                Name = destination.Name,
                City = destination.City,
                Description = destination.Description,
                Country = destination.Country,
                Category = destination.Category,
            };

            return View(destinationViewModel);
        }


        // POST: /Destinantion/Update?{DestinationID}
        [HttpPost]
        public async Task<IActionResult> Update(Guid DestinationID, DestinationUpdateDto destinationData)
        {
            if (ModelState.IsValid)
            {
                await _destinationService.UpdateAsync(DestinationID, destinationData);

                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = "Cập nhật thông tin địa điểm thành công";

                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Không tìm thấy dữ liệu địa điểm id: {DestinationID}";
            return View();
        }

        // POST: /Destination/Delete?{DestinationID}
        public async Task<IActionResult> Delete(Guid DestinationID)
        {
            await _destinationService.DeleteAsync(DestinationID);
            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành công!";
            TempData["NotificationMessage"] = "Xóa địa điểm thành công";
            return RedirectToAction("Index");
        }
    }
}