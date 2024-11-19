using Application.DTOs.CustomerDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;
        public CustomerController(ICustomerService customerService, IAccountService accountService)
        {
            _customerService = customerService;
            _accountService = accountService;
        }

        [Authorize(Policy = "customer-detail")]
        public async Task<IActionResult> Detail(Guid CustomerID)
        {
            // Lấy tất cả khách hàng
            var customers = await _customerService.GetById(CustomerID);

            // Tạo CustomerViewModel từ thông tin khách hàng và tài khoản
            var customerViewModel = new CustomerViewModel
            {
                CustomerID = customers.CustomerID,
                FirstName = customers.FirstName,
                LastName = customers.LastName,
                Address = customers.Address,
            };

            // Trả về View với danh sách CustomerViewModel
            return View(customerViewModel);
        }


        [Authorize(Policy = "customer-add")]
        // GET: /Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        [HttpPost]
        [Authorize(Policy = "customer-add")]
        public async Task<IActionResult> Create(CustomerCreationDto customer)
        {
            if (ModelState.IsValid)
            {
                var accountResult = await _accountService.CreateUserAsync(customer);
                if (accountResult.Result.Succeeded)
                {
                    customer.AccountID = accountResult.UserId;
                    await _customerService.CreateAsync(customer);
                    TempData["NotificationType"] = "success";
                    TempData["NotificationTitle"] = "Thành Công!";
                    TempData["NotificationMessage"] = "Thêm nhân viên thành công!";

                    return RedirectToAction("Index");
                }

                // Xử lý nếu tạo tài khoản không thành công
                foreach (var error in accountResult.Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(customer);

            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ!";
            return View(customer);
        }

        [Authorize(Policy = "customer-update")]
        // GET: /Customer/Update?{customer_id}
        public async Task<IActionResult> Update(Guid CustomerID)
        {
            var customer = await _customerService.GetById(CustomerID);
            if (customer == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không thể lấy giữ liệu từ id: {CustomerID}";
                return View();
            }
            var customerViewModel = new CustomerViewModel
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                Phone = customer.Phone,

            };
            return View(customerViewModel);
        }

        // POST: /Customer/Update?{CustomerID}
        [HttpPost]
        [Authorize(Policy = "customer-update")]
        public async Task<IActionResult> Update(Guid CustomerID, CustomerUpdateDto customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.UpdateAsync(CustomerID, customer);

                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = $"Cập nhật thông tin nhân viên {customer.FirstName} thành công!";
                return RedirectToAction("Index");
            }

            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ!";
            return View();
        }
    }
}