using Application.DTOs.EmployeeDTOs;
using Application.DTOs.TourEmployeeDTOs;
using Application.Services;
using Application.Services_Interface;
using Domain.Entities;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Areas.Admin.Models;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Policy = "RequiredAdminOrManager")]
    [Area("Admin")]
    public class TourEmployeeController : Controller
    {
        private readonly ITourEmployeeService _tourEmployeeService;
        private readonly ITourService _tourService;
        private readonly IEmployeeService _employeeService;

        public TourEmployeeController(ITourEmployeeService tourEmployeeService, ITourService tourService, IEmployeeService employeeService)
        {
            _tourEmployeeService = tourEmployeeService;
            _tourService = tourService;
            _employeeService = employeeService;
        }

        // GET: /TourEmployee/
        [Authorize(Policy = "tour-employee-view")]
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

            var employees = await _tourEmployeeService.GetByTourIdAsync(TourID);


            var employeesViewModel = employees.Select(x => new TourDetailEmployeeViewModel
            {
                EmployeeID = x.EmployeeID,
                FullName = x.Employee.FirstName + x.Employee.LastName,
                Phone = x.Employee.Phone,
                Email = x.Employee.Email,
                Position = x.Employee.Position,
                Image = x.Employee.Image,

            }).ToList();

            var tourEmployeeViewModel = new TourEmployeeViewModel
            {
                TourID = TourID,
                TourName = tour.Title,
                Employees = employeesViewModel
            };
            return View(tourEmployeeViewModel);
        }

        [Authorize(Policy = "tour-employee-add")]
        public async Task<IActionResult> Create(Guid TourID)
        {
            var employees = await _employeeService.GetAllWithOutTour(TourID);
            var employeesViewModel = employees.Select(i => new TourDetailEmployeeViewModel
            {
                EmployeeID = i.EmployeeID,
                FullName = i.Position + " - " + i.FirstName + " " +i.LastName,

            }).ToList();
            var employeesSelectList = new SelectList(employeesViewModel, "EmployeeID", "FullName");

            ViewBag.EmployeeList = employeesSelectList;


            var tourEmployeeViewModel = new TourEmployeeCreationDto
            {
                TourID = TourID
            };
            return View(tourEmployeeViewModel);
        }

        // POST: /TourEmployee/Create
        [HttpPost]
        [Authorize(Policy = "tour-employee-add")]
        public async Task<IActionResult> Create(TourEmployeeCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _tourEmployeeService.CreateAsync(dto);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = "Thêm nhân viên vào Tour thành công!";
                return RedirectToAction("Index" , new {TourId = dto.TourID});
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            return View();
        }

        [Authorize(Policy = "tour-employee-delete")]
        public async Task<IActionResult> Delete(Guid TourID, Guid EmployeeID)
        {
            await _tourEmployeeService.DeleteAsync(TourID, EmployeeID);
            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành Công!";
            TempData["NotificationMessage"] = "Xóa nhân viên trong Tour thành công!";
            return RedirectToAction("Index", new {  TourID });
        }


    }
}