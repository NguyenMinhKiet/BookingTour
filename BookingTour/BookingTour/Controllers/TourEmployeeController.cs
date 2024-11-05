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
                var employee = employees.FirstOrDefault(a => a.employee_id == i.employee_id);

                return new TourEmployeeViewModel
                {
                    tour_id = i.tour_id,
                    employee_id = i.employee_id,
                    // Sử dụng toán tử null-coalescing để xử lý trường hợp employee null
                    employee_name = employee != null ? $"{employee.first_name} {employee.last_name}" : "N/A",
                    position = employee?.position switch
                    {
                        2 => "Hướng dẫn viên",
                        3 => "Tài xế",
                        _ => "N/A"
                    }
                };
            }).ToList();


            return View(tourEmployeesViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var tours = await _tourService.GetAllAsync();
            var toursViewModel = tours.Select(i => new TourViewModel
            {
                tour_name = i.tour_name,
                tour_id = i.tour_id,

            }).ToList();
            var toursSelectList = new SelectList(toursViewModel, "tour_id", "tour_name");

            var employees = await _employeeService.GetAllAsync();
            var employeesViewModel = employees.Select(i => new EmployeeViewModel
            {
                employee_id = i.employee_id,
                full_name = i.first_name + " " + i.last_name
            }).ToList();
            var employeesSelectList = new SelectList(employeesViewModel, "employee_id", "full_name");

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
                TempData["success"] = $"Thêm nhân viên {dto.employee_id} vào tour {dto.tour_id} thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = $"Thêm nhân viên {dto.employee_id} vào tour {dto.tour_id} thất bại.";
            return View();
        }

        public async Task<IActionResult> Delete(int tour_id, int employee_id)
        {
            await _tourEmployeeService.DeleteAsync(tour_id, employee_id);
            TempData["success"] = $"Xóa nhân viên {employee_id} trong tour {tour_id} thành công.";
            return RedirectToAction("Index");
        }
    }
}
