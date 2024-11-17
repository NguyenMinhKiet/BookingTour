using Application.DTOs.DestinationDTOs;
using Application.DTOs.LocationDto;
using Application.Services_Interface;
using Domain.Entities.Location;
using Infrastructure.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Admin.Models;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Policy = "RequiredAdminOrManager")]
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly ILocationService _locationService;

        public DestinationController(IDestinationService destinationService, ILocationService locationService)
        {
            _destinationService = destinationService;
            _locationService = locationService;
        }

        // GET: /Destination/
        [Authorize(Policy = "destination-view")]
        public async Task<IActionResult> Index()
        {
            var destiations = await _destinationService.GetAllAsync();
            var destinationsViewModel = destiations.Select(i => new Models.DestinationViewModel
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

        // Controller method
        [Authorize(Policy = "destination-add")]
        public async Task<IActionResult> Create()
        {
            var listCity = await _locationService.LoadAllCitysAsync();
            var listCityViewModel = listCity.Select(e => new CityViewModel
            {
                Name = NORMALIZE.NormalizeCity(e.Name),
            }).ToList();
    
            ViewData["ListCity"] = listCityViewModel;

            // Debug: Kiểm tra dữ liệu trong TempData

            return View();
        }


        // POST: /Destination/Create
        [HttpPost]
        [Authorize(Policy = "destination-add")]
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
        [Authorize(Policy = "destination-update")]
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

            var destinationViewModel = new Models.DestinationViewModel
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
        [Authorize(Policy = "destination-update")]
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
        [Authorize(Policy = "destination-delete")]
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