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
                destination_id = i.destination_id,
                destination_name = i.destination_name,
                description = i.description,
                city = i.city,
                country = i.country,
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


        // GET: /Destination/Update?{destination_id}
        public async Task<IActionResult> Update(int destination_id)
        {
            var destination = await _destinationService.GetById(destination_id);

            if(destination == null) {
                TempData["error"] = "Không tìm thấy địa điểm " + destination_id;
                return RedirectToAction("Index");
            }

            var destinationViewModel = new DestinationViewModel
            {
                destination_id = destination.destination_id,
                destination_name = destination.destination_name,
                city = destination.city,
                description = destination.description,
                country = destination.country,
            };

            return View(destinationViewModel);
        }


        // POST: /Destinantion/Update?{destination_id}
        [HttpPost]
        public async Task<IActionResult> Update(int destination_id, DestinationUpdateDto destinationData)
        {
            if(ModelState.IsValid)
            {
                await _destinationService.UpdateAsync(destination_id, destinationData);
                TempData["success"] = "Thay đổi thông tin địa điểm thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Không tìm thấy địa điểm !!";
            return View();
        }

        // POST: /Destination/Delete?{destination_id}
        public async Task<IActionResult>Delete(int destination_id)
        {
            //await _destinationService.DeleteAsync(destination_id);
            TempData["success"] = "Xóa địa điểm " + destination_id + " thành công.";
            return RedirectToAction("Index");
        }
    }
}
