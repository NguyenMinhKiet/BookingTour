using Application.DTOs.CustomerDTOs;
using Application.DTOs.EmployeeDTOs;
using Application.Services;
using Application.Services_Interface;
using Domain.Entities;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAccountService _accountService;
        private readonly UserManager<Account> _userManager;

        public EmployeeController(IEmployeeService employeeService, IAccountService accountService, UserManager<Account> userManager)
        {
            _employeeService = employeeService;
            _accountService = accountService;
            _userManager = userManager;
        }

        [Authorize(Policy = "employee-view")]
        public async Task<IActionResult> Index(Guid EmployeeID)
        {
            var employees = await _employeeService.GetById(EmployeeID);

            var employeeModelView = new EmployeeViewModel
            {
                EmployeeID = employees.EmployeeID,
                FirstName = employees.FirstName,
                LastName = employees.LastName,
                Position = employees.Position,
                Address = employees.Address,
            };

            return View(employeeModelView);
        }

        // GET: /Employee/Update?{customer_id}
        [Authorize(Policy = "employee-update")]
        public async Task<IActionResult> Update(Guid EmployeeID)
        {

            var employee = await _employeeService.GetById(EmployeeID);
            if (employee == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy dữ liệu địa điểm id: {EmployeeID}";
                return RedirectToAction("Index");
            }
            var employeeViewData = new EmployeeViewModel
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                Address = employee.Address,
                Email = employee.Email,
                Phone = employee.Phone,
            };

            return View(employeeViewData);
        }

        // POST: /Employee/Update?{customer_id}
        [HttpPost]
        [Authorize(Policy = "employee-update")]
        public async Task<IActionResult> Update(Guid EmployeeID, EmployeeUpdateDto employee)
        {

            if (ModelState.IsValid)
            {
                await _employeeService.UpdateAsync(EmployeeID, employee);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = "Cập nhật thông tin nhân viên thành công";
                return RedirectToAction("Index");

            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Không tìm thấy nhân viên {EmployeeID}";
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "profile-view")]
        public async Task<IActionResult> ViewProfile(Guid UserID)
        {
            var user = await _userManager.FindByIdAsync(UserID.ToString());
            if (user != null)
            {
                var employee = await _employeeService.GetById(user.Id);
                var employeeModel = new EmployeeViewModel
                {
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Phone = employee.Phone,
                    Address = employee.Address,
                    Email = employee.Email,
                };
                return View(employeeModel);
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại";
            TempData["NotificationMessage"] = "Vui lòng đăng nhập.";
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [Authorize(Policy = "profile-update")]
        public async Task<IActionResult> ViewProfile(Guid EmployeeID, EmployeeUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateAsync(EmployeeID, model);
                await _accountService.UpdateUserProfileAsync(EmployeeID, model.Phone);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = $"Cập nhật thông tin user thành công!";
                return RedirectToAction("ViewProfile", new { UserID =  EmployeeID });
            }

            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ!";
            return View(model);
        }
    }
}