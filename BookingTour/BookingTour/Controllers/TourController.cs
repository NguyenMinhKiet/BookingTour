using Application.DTOs.DestinationDTOs;
using Application.DTOs.EmployeeDTOs;
using Application.DTOs.LocationDto;
using Application.DTOs.TourDTOs;
using Application.Services_Interface;
using Infrastructure.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ILocationService _locationService;
        public TourController(ITourService tourService, ILocationService locationService)
        {
            _tourService = tourService;
            _locationService = locationService;
        }

        // GET: /Tour/
        [Authorize(Policy = "tour-view")]
        public async Task<IActionResult> Index()
        {
            var tours = await _tourService.GetAllAsync();
            var toursViewModel = tours.Select(i => new TourViewModel
            {
                TourID = i.TourID,
                Title = i.Title,
                Description = i.Description,
                Price = i.Price,
                AvailableSeats = i.AvailableSeats,
                StartDate = i.StartDate,
                EndDate = i.EndDate,
                Category = i.Category,
                City = i.City

            }).ToList();

            return View(toursViewModel);
        }

        // GET: /Tour/Create
        [Authorize(Policy = "tour-add")]
        public async Task<IActionResult> CreateAsync()
        {
            var listCity = await _locationService.LoadAllCitysAsync();
            var listCityViewModel = listCity.Select(e => new CityViewModel
            {
                Name = NORMALIZE.NormalizeCity(e.Name),
            }).ToList();

            ViewData["ListCity"] = listCityViewModel;
            return View();
        }

        // POST: /Tour/Create
        [HttpPost]
        [Authorize(Policy = "tour-add")]
        public async Task<IActionResult> Create(TourCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourService.CreateAsync(dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Thêm Tour thành công!";
                return RedirectToAction("Index");
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
        // GET: /Tour/Update?{TourID}
        [Authorize(Policy = "tour-update")]
        public async Task<IActionResult> Update(Guid TourID)
        {
            var i = await _tourService.GetByIdAsync(TourID);
            if (i == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy Tour ID: {TourID}";
                return RedirectToAction("Index");
            }
            var tourViewModel = new TourViewModel
            {
                TourID = i.TourID,
                Title = i.Title,
                Description = i.Description,
                Price = i.Price,
                AvailableSeats = i.AvailableSeats,
                StartDate = i.StartDate,
                EndDate = i.EndDate,
                Category = i.Category,
                City = i.City
            };
            return View(tourViewModel);

        }

        // POST: /Tour/Update?{TourID}
        [HttpPost]
        [Authorize(Policy = "tour-update")]
        public async Task<IActionResult> Update(Guid TourID, TourUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourService.UpdateAsync(TourID, dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Cập nhật thông tin Tour thành công!";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            return View();
        }

        // POST: /Tour/Delete?{TourID}
        [Authorize(Policy = "tour-delete")]
        public async Task<IActionResult> Delete(Guid TourID)
        {
            await _tourService.DeleteAsync(TourID);
            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành Công!";
            TempData["NotificationMessage"] = "Xóa Tour thành công!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid TourID)
        {
            var tour = await _tourService.GetByIdAsync(TourID);
            if(tour == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy Tour: {TourID}!";
                return RedirectToAction("Index");
            }

            var destinations = await _tourService.GetDestinations(tour.TourID);
            var destinationsViewModel = destinations.Select(d => new DestinationWithVisitDateViewModel
            {
                DestinationID = d.DestinationID,
                Name = d.Destination.Name,
                Description = d.Destination.Description,
                Country = d.Destination.Country,
                Category = d.Destination.Category,
                City = d.Destination.City,
                visitDate = d.VisitDate,
            }).ToList();
            
            var employees = await _tourService.GetEmployees(tour.TourID);
            var employeesViewModel = employees.Select(e => new TourDetailEmployeeViewModel
            {
                EmployeeID = e.EmployeeID,
                FullName = e.Employee.FirstName + " " + e.Employee.LastName,
                Phone = e.Employee.Phone,
                Position = e.Employee.Position,
                Email = e.Employee.Email,

            }).ToList();
            var tourDestinationViewModel = new TourDetailViewModel
            {
                TourID = tour.TourID,
                TourName = tour.Title,
                Destinations = destinationsViewModel,
                Employees = employeesViewModel,
            };
            return View(destinationsViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> GetToursByCategory(List<string> categories)
        {
            try
            {
                Console.WriteLine(categories.ToList());

                var tours = await _tourService.GetToursByCategoriesAsync(categories);
                return Json(new
                {
                    success = true,
                    data = tours
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Error occurred: " + ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTours()
        {
            try
            {
                var tours = await _tourService.GetAllAsync(); // Đảm bảo bạn đợi kết quả từ DB
                return Json(new { success = true, data = tours });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


    }
}