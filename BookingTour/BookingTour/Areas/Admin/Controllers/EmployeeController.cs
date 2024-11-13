using Application.DTOs.AccountDTOs;
using Application.DTOs.EmployeeDTOs;
using Application.Services_Interface;
using Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAccountService _accountService;

        public EmployeeController(IEmployeeService employeeService, IAccountService accountService)
        {
            _employeeService = employeeService;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllAsync();
            var employeesViewModel = new List<EmployeeViewModel>();

            foreach (var c in employees)
            {
                var acc = await _accountService.GetById(c.AccountID);
                var employeeModelView = new EmployeeViewModel
                {
                    EmployeeID = c.EmployeeID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Position = c.Position,
                    Address = c.Address,
                    AccountID = acc.Id,
                    Phone = acc.Phone,
                    Username = acc.Username,
                    Password = acc.Password,
                    Email = acc.Email,
                    isActive = acc.isActive

                };
                employeesViewModel.Add(employeeModelView);
            }

            return View(employeesViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }


        // POST: /Employee/Create
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreationDto employee, AccountCreateDto acc)
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
                var CreateAccount = await _accountService.CreateAsync(acc);
                if (CreateAccount != null)
                {
                    await _employeeService.CreateAsync(employee);
                    TempData["NotificationType"] = "success";
                    TempData["NotificationTitle"] = "Thành công!";
                    TempData["NotificationMessage"] = "Thêm nhân viên thành công";
                    return RedirectToAction("Index");
                }
                TempData["NotificationType"] = "error";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = "không thể tạo tài khoản";
                return View();
            }
            TempData["NotificationType"] = "error";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
            return View();
        }


        // GET: /Employee/Update?{customer_id}
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
            var acc = await _accountService.GetById(employee.AccountID);
            var employeeViewData = new EmployeeViewModel
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Position = employee.Position,
                Address = employee.Address,
                AccountID = acc.Id,
                Username = acc.Username,
                Password = acc.Password,
                Phone = acc.Phone,
                Email = acc.Email,
                isActive = acc.isActive
            };

            return View(employeeViewData);
        }

        // POST: /Employee/Update?{customer_id}
        [HttpPost]
        public async Task<IActionResult> Update(Guid EmployeeID, Guid AccountID, EmployeeUpdateDto employee, AccountUpdateDto account)
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
                await _accountService.UpdateAsync(AccountID, account);
                await _employeeService.UpdateAsync(EmployeeID, employee);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = "Cập nhật thông tin nhân viên thành công";
                return RedirectToAction("Index");

            }
            TempData["error"] = "Không tìm thấy nhân viên !!";
            return View();
        }

        public async Task<IActionResult> Delete(Guid EmployeeID)
        {
            var customer = await _employeeService.GetById(EmployeeID);
            if (customer != null)
            {
                await _accountService.DeleteAsync(customer.AccountID);
                await _employeeService.DeleteAsync(EmployeeID);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = "Xóa nhân viên thành công";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Không tìm thấy dữ liệu địa điểm id: {EmployeeID}";
            return RedirectToAction("Index");

        }
    }
}