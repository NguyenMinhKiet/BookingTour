﻿using Application.DTOs.TourEmployeeDTOs;
using Application.Services_Interface;
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
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllAsync();

            var tourEmployees = await _tourEmployeeService.GetAllAsync();

            var tourEmployeesViewModel = tourEmployees.Select(i =>

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

        [Authorize(Policy = "tour-employee-add")]
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
                FirstName = i.FirstName
            }).ToList();
            var employeesSelectList = new SelectList(employeesViewModel, "EmployeeID", "FirstName");

            ViewBag.TourList = toursSelectList;
            ViewBag.EmployeeList = employeesSelectList;

            return View();
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

        [Authorize(Policy = "tour-employee-delete")]
        public async Task<IActionResult> Delete(Guid tour_id, Guid employee_id)
        {
            await _tourEmployeeService.DeleteAsync(tour_id, employee_id);
            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành Công!";
            TempData["NotificationMessage"] = "Xóa nhân viên trong Tour thành công!";
            return RedirectToAction("Index");
        }


    }
}