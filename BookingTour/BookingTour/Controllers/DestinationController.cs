using Application.DTOs.DestinationDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        // GET: /Destination/
        public async Task<IActionResult> Index()
        {
            var destiations = await _destinationService.GetAllAsync();
            var destinationsViewModel = destiations.Select(i=> new DestinationViewModel
            {
                DestinationID = i.DestinationID,
                Name = i.Name,
                Description = i.Description,
                City = i.City,
                Country = i.Country,
            }).ToList();

            return View(destinationsViewModel);
        }

        // GET: /Destination/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Destination/Create
        [HttpPost]
        public async Task<IActionResult> Create(DestinationCreationDto destination)
        {
            if (ModelState.IsValid)
            {
                await _destinationService.CreateAsync(destination);
                TempData["success"] = "Thêm địa điểm mới thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thêm địa điểm mới thất bại.";
            return View();
        }


        // GET: /Destination/Update?{DestinationID}
        public async Task<IActionResult> Update(Guid DestinationID)
        {
            var destination = await _destinationService.GetById(DestinationID);

            if(destination == null) {
                TempData["error"] = "Không tìm thấy địa điểm " + DestinationID;
                return RedirectToAction("Index");
            }

            var destinationViewModel = new DestinationViewModel
            {
                DestinationID = destination.DestinationID,
                Name = destination.Name,
                City = destination.City,
                Description = destination.Description,
                Country = destination.Country,
            };

            return View(destinationViewModel);
        }


        // POST: /Destinantion/Update?{DestinationID}
        [HttpPost]
        public async Task<IActionResult> Update(Guid DestinationID, DestinationUpdateDto destinationData)
        {
            if(ModelState.IsValid)
            {
                await _destinationService.UpdateAsync(DestinationID, destinationData);
                TempData["success"] = "Thay đổi thông tin địa điểm thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Không tìm thấy địa điểm !!";
            return View();
        }

        // POST: /Destination/Delete?{DestinationID}
        public async Task<IActionResult>Delete(Guid DestinationID)
        {
            await _destinationService.DeleteAsync(DestinationID);
            TempData["success"] = "Xóa địa điểm " + DestinationID + " thành công.";
            return RedirectToAction("Index");
        }
    }
}
