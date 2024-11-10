using Application.DTOs.TourEmployeeDTOs;
using Application.Services;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class TourEmployeeController : Controller
    {
        private readonly ITourEmployeeService _tourEmployeeService;
        private readonly ITourService _tourService;
        private readonly IEmployeeService _employeeService;

        public TourEmployeeController (ITourEmployeeService tourEmployeeService , ITourService tourService, IEmployeeService employeeService)
        {
            _tourEmployeeService = tourEmployeeService;
            _tourService = tourService;
            _employeeService = employeeService;
        }

        // GET: /TourEmployee/
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllAsync();

            var tourEmployees = await _tourEmployeeService.GetAllAsync();

            var tourEmployeesViewModel = tourEmployees.Select( i =>

            {
                // Tìm kiếm nhân viên một lần và lưu vào biến
                var employee = employees.FirstOrDefault(a => a.EmployeeID == i.EmployeeID);

                return new TourEmployeeViewModel
                {
                    TourID = i.TourID,
                    EmployeeID = i.EmployeeID,
                    Name = employee.LastName,
                    Position = employee.Position
                };
            }).ToList();


            return View(tourEmployeesViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var tours = await _tourService.GetAllAsync();
            var toursViewModel = tours.Select(i => new TourViewModel
            {
                Title = i.Title,
                TourID = i.TourID,

            }).ToList();
            var toursSelectList = new SelectList(toursViewModel, "TourID", "Title");

            var employees = await _employeeService.GetAllAsync();
            var employeesViewModel = employees.Select(i => new EmployeeViewModel
            {
                EmployeeID = i.EmployeeID,
                Position = i.Position
            }).ToList();
            var employeesSelectList = new SelectList(employeesViewModel, "EmployeeID", "Position");

            ViewBag.TourList = toursSelectList;
            ViewBag.EmployeeList = employeesSelectList;

            return View();
        }

        // POST: /TourEmployee/Create
        [HttpPost]
        public  async Task<IActionResult> Create(TourEmployeeCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourEmployeeService.CreateAsync(dto);
                TempData["success"] = $"Thêm nhân viên {dto.EmployeeID} vào tour {dto.TourID} thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = $"Thêm nhân viên {dto.EmployeeID} vào tour {dto.TourID} thất bại.";
            return View();
        }

        public async Task<IActionResult> Delete(Guid tour_id, Guid employee_id)
        {
            await _tourEmployeeService.DeleteAsync(tour_id, employee_id);
            TempData["success"] = $"Xóa nhân viên {employee_id} trong tour {tour_id} thành công.";
            return RedirectToAction("Index");
        }
    }
}
