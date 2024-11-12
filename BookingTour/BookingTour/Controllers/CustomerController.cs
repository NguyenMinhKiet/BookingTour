
using Application.DTOs.AccountDTOs;
using Application.DTOs.CustomerDTOs;
using Application.Services_Interface;
using Domain.Entities;
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

        public async Task<IActionResult> Index()
        {
            // Lấy tất cả khách hàng
            var customers = await _customerService.GetAllAsync();

            // Khởi tạo danh sách CustomerViewModel
            var customersViewModel = new List<CustomerViewModel>();

            // Duyệt qua từng khách hàng và lấy thông tin tài khoản
            foreach (var c in customers)
            {
                var acc = await _accountService.GetById(c.AccountID);

                // Tạo CustomerViewModel từ thông tin khách hàng và tài khoản
                var customerViewModel = new CustomerViewModel
                {
                    CustomerID = c.CustomerID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address,
                    AccountID = acc.Id,
                    Phone = acc.Phone,
                    Username = acc.Username,
                    Password = acc.Password,
                    Email = acc.Email,
                    isActive = acc.isActive
                };

                // Thêm vào danh sách
                customersViewModel.Add(customerViewModel);
            }

            // Trả về View với danh sách CustomerViewModel
            return View(customersViewModel);
        }
        
        // GET: /Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreationDto customer, AccountCreateDto acc)
        {
            //if (string.IsNullOrEmpty(customer?.FirstName))
            //{
            //    ModelState.AddModelError("first_name", errorMessage: $"Vui lòng nhập đầy đủ họ đệm bạn đã nhập: {customer.first_name.Length} ký tự !! ");
            //}

            //if (string.IsNullOrEmpty(customer?.Phone) || customer.Phone.Length != 10)
            //{
            //    ModelState.AddModelError("phone", errorMessage: $"Số điện thoại phải có 10 kí tự số, bạn đã nhập: {customer.phone.Length} ký tự !!");
            //}

            //if (string.IsNullOrEmpty(customer?.Email) || !customer.Email.Contains("@"))
            //{
            //    ModelState.AddModelError("email", errorMessage: "Email thiếu '@'!!");
            //}


            //if (string.IsNullOrEmpty(customer?.LastName))
            //{
            //    ModelState.AddModelError("last_name", errorMessage: $"Vui lòng nhập đầy đủ họ đệm, bạn đã nhập: {customer.last_name.Length} ký tự !! ");
            //}

            if (ModelState.IsValid)
            {
                var CreateAccount = await _accountService.CreateAsync(acc);
                if(CreateAccount != null)
                {
                    customer.AccountID = CreateAccount.Id;
                    
                    await _customerService.CreateAsync(customer);

                    TempData["NotificationType"] = "success";
                    TempData["NotificationTitle"] = "Thành Công!";
                    TempData["NotificationMessage"] = "Thêm nhân viên thành công!";

                    return RedirectToAction("Index");
                }

                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = "Không thể thêm nhân viên, hãy kiểm tra lại các thông tin!";

                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ!";
            return View();
        }

        // GET: /Customer/Update?{customer_id}
        public async Task<IActionResult> Update(Guid CustomerID)
        {
            var customer = await _customerService.GetById(CustomerID);
            if(customer == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không thể lấy giữ liệu từ id: {CustomerID}";
                return View();
            }
            var acc = await _accountService.GetById(customer.AccountID);
            var customerViewModel = new CustomerViewModel
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                AccountID = acc.Id,
                Username = acc.Username,
                Password = acc.Password,
                Phone = acc.Phone,
                Email = acc.Email,
                isActive = acc.isActive
            };
            return View(customerViewModel);
        }

        // POST: /Customer/Update?{CustomerID}
        [HttpPost]
        public async Task<IActionResult> Update(Guid CustomerID,Guid AccountID, CustomerUpdateDto customer, AccountUpdateDto account)
        {
            if (ModelState.IsValid)
            {
                await _accountService.UpdateAsync(AccountID, account);
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

        // POST: /Customer/Delete?{customer_id}
        public async Task<IActionResult> Delete(Guid CustomerID)
        {
            var customer = await _customerService.GetById(CustomerID);
            if (customer != null)
            {
                await _customerService.DeleteAsync(CustomerID);
                await _accountService.DeleteAsync(customer.AccountID);
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành Công!";
                TempData["NotificationMessage"] = $"Xóa nhân viên {customer.FirstName}!";
                return RedirectToAction("Index");
            }

            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Không tìm thấy khách hàng";
            return RedirectToAction("Index");

        }
    }
}
