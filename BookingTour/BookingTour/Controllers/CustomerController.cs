
using Application.DTOs.CustomerDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllAsync();
            var customersViewModel = customers.Select(c => new CustomerViewModel
            {
                customer_id = c.customer_id,
                first_name = c.first_name,
                last_name = c.last_name,
                email = c.email,
                phone = c.phone,
                address = c.address,
            }).ToList();
            return View(customersViewModel);
        }
        
        // GET: /Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreationDto customer)
        {
            if (string.IsNullOrEmpty(customer?.first_name) || customer.first_name.Length < 3)
            {
                ModelState.AddModelError("first_name", errorMessage: $"Vui lòng nhập đầy đủ họ đệm với ít nhất 3 ký tự, bạn đã nhập: {customer.first_name.Length} ký tự !! ");
            }

            if (string.IsNullOrEmpty(customer?.phone) || customer.phone.Length != 10)
            {
                ModelState.AddModelError("phone", errorMessage: $"Số điện thoại phải có 10 kí tự số, bạn đã nhập: {customer.phone.Length} ký tự !!");
            }

            if (string.IsNullOrEmpty(customer?.email) || !customer.email.Contains("@"))
            {
                ModelState.AddModelError("email", errorMessage: "Email thiếu '@'!!");
            }


            if (string.IsNullOrEmpty(customer?.last_name) || customer.last_name.Length < 3)
            {
                ModelState.AddModelError("last_name", errorMessage: $"Vui lòng nhập đầy đủ họ đệm với ít nhất 3 ký tự, bạn đã nhập: {customer.last_name.Length} ký tự !! ");
            }

            if (ModelState.IsValid)
            {
                await _customerService.CreateAsync(customer);
                TempData["success"] = "Thêm khách hàng mới thành công.";
                return RedirectToAction("Index");
            }
            
            TempData["error"] = "Thêm khách hàng mới thất bại !!";
            return View();
        }

        // GET: /Customer/Update?{customer_id}
        public async Task<IActionResult> Update(int customer_id)
        {
            var customer = await _customerService.GetById(customer_id);
            if(customer == null)
            {
                return RedirectToAction("Error", "Shared");
            }

            var customerViewModel = new CustomerViewModel
            {
                customer_id = customer.customer_id,
                first_name = customer.first_name,
                last_name = customer.last_name,
                email = customer.email,
                phone = customer.phone,
                address = customer.address,
            };
            return View(customerViewModel);
        }

        // POST: /Customer/Update?{customer_id}
        [HttpPost]
        public async Task<IActionResult> Update(int customer_id, CustomerUpdateDto customer)
        {
            if (string.IsNullOrEmpty(customer?.first_name) || customer.first_name.Length < 3)
            {
                ModelState.AddModelError("first_name", errorMessage: $"Vui lòng nhập đầy đủ họ đệm với ít nhất 3 ký tự, bạn đã nhập: {customer.first_name.Length} ký tự !! ");
            }

            if (string.IsNullOrEmpty(customer?.phone) || customer.phone.Length != 10)
            {
                ModelState.AddModelError("phone", errorMessage: $"Số điện thoại phải có 10 kí tự số, bạn đã nhập: {customer.phone.Length} ký tự !!");
            }

            if (string.IsNullOrEmpty(customer?.email) || !customer.email.Contains("@"))
            {
                ModelState.AddModelError("email", errorMessage: "Email thiếu '@'!!");
            }

            if (string.IsNullOrEmpty(customer?.last_name) || customer.last_name.Length < 3)
            {
                ModelState.AddModelError("last_name", errorMessage: $"Vui lòng nhập đầy đủ họ đệm với ít nhất 3 ký tự, bạn đã nhập: {customer.last_name.Length} ký tự !! ");
            }

            if (ModelState.IsValid)
            {
                    await _customerService.UpdateAsync(customer_id, customer);
                    TempData["success"] = "Thay đổi thông tin khách hàng " + customer_id + " thành công.";
                    return RedirectToAction("Index");
            }
            TempData["error"] = "Không tìm thấy khách hàng !!";
            return View();
        }

        // POST: /Customer/Delete?{customer_id}
        public async Task<IActionResult> Delete(int customer_id)
        {
            await _customerService.DeleteAsync(customer_id);
            TempData["success"] = "Đã xóa khách hàng " + customer_id;
            return RedirectToAction("Index");
        }
    }
}
