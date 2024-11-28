using Application.DTOs.DestinationDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var destinations = await _destinationService.GetAllAsync();
            var destinationsViewModelTasks = destinations.AsEnumerable().Select(async i =>
            {
                return new Models.DestinationViewModel
                {
                    DestinationID = i.DestinationID,
                    Name = i.Name,
                    Description = i.Description,
                    Country = i.Country,
                    Category = i.Category,
                    SelectedCity = i.City,
                    SelectedDistrict = i.District,
                    SelectedWard = i.Ward,
                    Address = i.Address,
                    Image = i.Image,    
                };
            }).ToList();

            var destinationsViewModel = (await Task.WhenAll(destinationsViewModelTasks)).ToList();
            ViewData["ActivePage"] = "TourManager";
            return View(destinationsViewModel);
        }

        // Controller method
        [Authorize(Policy = "destination-add")]
        public async Task<IActionResult> Create()
        {
            var listCity = await _locationService.LoadAllCitysAsync();

            ViewBag.Cities = listCity.Select(c => new SelectListItem
            {
                Value = c.Code,
                Text = c.Name
            }).OrderBy(x=>x.Text).ToList();
            ViewData["ActivePage"] = "TourManager";
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
            var listCity = await _locationService.LoadAllCitysAsync();
            
            ViewBag.Cities = listCity.Select(c => new SelectListItem
            {
                Value = c.Code,
                Text = c.Name
            }).ToList();
            return View(destination);
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
                ViewData["ActivePage"] = "TourManager";
                return RedirectToAction("Index");
            }
            
            var destinationViewModel = new DestinationUpdateDto
            {
                DestinationID = destination.DestinationID,
                Name = destination.Name,
                Description = destination.Description,
                Country = destination.Country,
                Category = destination.Category,
                City = destination.City,
                District = destination.District,
                Ward = destination.Ward,
                Address = destination.Address,
                Image = destination.Image,
            };

            var listCity = await _locationService.LoadAllCitysAsync();
            ViewBag.Cities = listCity.Select(c => new SelectListItem
            {
                Value = c.Code,
                Text = c.Name
            }).OrderBy(x => x.Text).ToList();
            await GetDistricts(destinationViewModel.City);
            await GetWards(destinationViewModel.City, destinationViewModel.District);
            ViewData["ActivePage"] = "TourManager";
            return View(destinationViewModel);
        }


        // POST: /Destinantion/Update?{DestinationID}
        [HttpPost]
        [Authorize(Policy = "destination-update")]
        public async Task<IActionResult> Update(DestinationUpdateDto destination)
        {
            if (ModelState.IsValid)
            {

                await _destinationService.UpdateAsync(destination);

                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = "Cập nhật thông tin địa điểm thành công";

                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Dữ liệu không hợp lệ";

            var listCity = await _locationService.LoadAllCitysAsync();

            ViewBag.Cities = listCity.Select(c => new SelectListItem
            {
                Value = c.Code,
                Text = c.Name
            }).OrderBy(x => x.Text).ToList();
            await GetDistricts(destination.City);
            await GetWards(destination.City, destination.District);
            return View(destination);
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

        [HttpGet]
        public async Task<IActionResult> GetDistricts(string cityCode)
        {
            var cities = await _locationService.LoadAllCitysAsync();
            var city = cities.FirstOrDefault(c => c.Name == cityCode);
            if (city == null)
                return NotFound();

            var districts = city.District.Select(d => new SelectListItem
            {
                Value = d.Name,
                Text = $"{d.Pre} {d.Name}"
            }).OrderBy(x => x.Text).ToList();
            Console.WriteLine(districts);
            return Json(districts);
        }


        [HttpGet]
        public async Task<IActionResult> GetWards(string cityCode, string districtName)
        {
            var cities = await _locationService.LoadAllCitysAsync();
            var city = cities.FirstOrDefault(c => c.Name == cityCode);
            if (city == null)
                return NotFound();

            var district = city.District.FirstOrDefault(d => d.Name == districtName);
            if (district == null)
                return NotFound();

            var wards = district.Ward.Select(w => new SelectListItem
            {
                Value = w.Name,
                Text = $"{w.Pre} {w.Name}"
            }).OrderBy(x => x.Text).ToList();

            return Json(wards);
        }
    }
}