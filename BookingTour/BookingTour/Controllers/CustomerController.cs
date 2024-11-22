using Application.DTOs.CustomerDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;
        private readonly UserManager<Account> _userManager;
        public CustomerController(ICustomerService customerService, IAccountService accountService, UserManager<Account> userManager)
        {
            _customerService = customerService;
            _accountService = accountService;
            _userManager = userManager;
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

        [HttpGet]
        [Authorize(Policy ="profile-view")]
        public async Task<IActionResult> ViewProfile(Guid UserID)
        {
            var user = await _userManager.FindByIdAsync(UserID.ToString());
            if (user != null)
            {
                var customer = await _customerService.GetById(user.Id);
                var customerModel = new CustomerViewModel
                {
                    CustomerID = customer.CustomerID,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address = customer.Address,
                };
                return View(customerModel);
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại";
            TempData["NotificationMessage"] = "Vui lòng đăng nhập.";
            return RedirectToAction("Login", "Account");
        }

        
        [HttpPost]
        [Authorize(Policy = "profile-update")]
        public async Task<IActionResult> ViewProfile(Guid CustomerID, CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = new CustomerUpdateDto
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Phone = model.Phone,
                };
                await _customerService.UpdateAsync(CustomerID, dto);
                await _accountService.UpdateUserProfileAsync(CustomerID,dto.Phone);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = $"Cập nhật thông tin user thành công!";
                return RedirectToAction("ViewProfile", new {UserID = CustomerID});
            }

            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ!";
            return View(model);
        }

    }
}