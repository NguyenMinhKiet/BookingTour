using Application.DTOs.EmployeeDTOs;
using Application.Services;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllAsync();
            var employeesViewModel = employees.Select(c => new EmployeeViewModel
            {
                EmployeeID = c.EmployeeID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                Position = c.Position,
                Address = c.Address,
                AccountID = c.AccountID

            }).ToList();
            return View(employeesViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }


        // POST: /Employee/Create
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreationDto employee)
        {
            //if (string.IsNullOrEmpty(employee?.first_name) || employee.first_name.Length < 3)
            //{
            //    ModelState.AddModelError("first_name", "Vui lòng nhập đầy đủ họ đệm với ít nhất 3 ký tự !");
            //}

            //if (string.IsNullOrEmpty(employee?.phone) || employee.phone.Length != 10)
            //{
            //    ModelState.AddModelError("phone", "Số điện thoại phải có 10 kí tự số, bạn đang có " + employee.phone.Length +" ký tự !!");
            //}

            //if (string.IsNullOrEmpty(employee?.email) || !employee.email.Contains("@"))
            //{
            //    ModelState.AddModelError("email", "Email thiếu '@' !!");
            //}

            //if (string.IsNullOrEmpty(employee?.last_name) || employee.last_name.Length < 3)
            //{
            //    ModelState.AddModelError("last_name", "Vui lòng nhập đầy đủ Tên với ít nhất 3 ký tự !!");
            //}

            //if (employee?.position == 0)
            //{
            //    ModelState.AddModelError("position", "Chọn vị trí !!");
            //}

            if (ModelState.IsValid)
            {
                await _employeeService.CreateAsync(employee);
                TempData["success"] = "Thêm nhân viên mới thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thêm nhân viên thất bại !!";
            return View();
        }


        // GET: /Employee/Update?{customer_id}
        public async Task<IActionResult>  Update(Guid employee_id)
        {
            
            var employee = await _employeeService.GetById(employee_id);
            if (employee == null)
            {
                return RedirectToAction("Error", "Shared");
            }

            var employeeViewData = new EmployeeViewModel
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                Position = employee.Position,
                Address = employee.Address,
                AccountID = employee.AccountID
            };

            return View(employeeViewData);
        }

        // POST: /Employee/Update?{customer_id}
        [HttpPost]
        public async Task<IActionResult>  Update(Guid employee_id, EmployeeUpdateDto employee)
        {
            //if (string.IsNullOrEmpty(employee?.first_name) || employee.first_name.Length < 3)
            //{
            //    ModelState.AddModelError("first_name", "Vui lòng nhập đầy đủ họ đệm với ít nhất 3 ký tự!");
            //}

            //if (string.IsNullOrEmpty(employee?.phone) || employee.phone.Length != 10)
            //{
            //    ModelState.AddModelError("phone", "Số điện thoại phải có 10 kí tự số, bạn đang có " + employee.phone.Length + " ký tự !!");
            //}

            //if (string.IsNullOrEmpty(employee?.email) || !employee.email.Contains("@"))
            //{
            //    ModelState.AddModelError("email", "Email thiếu '@'!!");
            //}

            //if (string.IsNullOrEmpty(employee?.last_name) || employee.last_name.Length < 3)
            //{
            //    ModelState.AddModelError("last_name", "Vui lòng nhập đầy đủ Tên với ít nhất 3 ký tự!!");
            //}

            if (ModelState.IsValid)
            {
                var employeeData = await _employeeService.GetById(employee_id);
                if (employeeData != null)
                {
                    await _employeeService.UpdateAsync(employee_id, employee);
                    TempData["success"] = "Cập nhật thông tin nhân viên " + employee_id + " thành công.";
                    return RedirectToAction("Index");
                }
                TempData["error"] = "Cập nhật thông tin nhân viên " + employee_id + " thất bại !!";
                return RedirectToAction("Index");

            }
            TempData["error"] = "Không tìm thấy nhân viên !!";
            return View();
        }

        public async Task<IActionResult>  Delete(Guid employee_id)
        {
            await _employeeService.DeleteAsync(employee_id);
            TempData["success"] = "Đã xóa nhân viên " + employee_id;
            return RedirectToAction("Index");
        }
    }
}
