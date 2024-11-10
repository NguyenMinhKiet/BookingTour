
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
                CustomerID = c.CustomerID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                AccountID = c.AccountID,

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
                await _customerService.CreateAsync(customer);
                TempData["success"] = "Thêm khách hàng mới thành công.";
                return RedirectToAction("Index");
            }
            
            TempData["error"] = "Thêm khách hàng mới thất bại !!";
            return View();
        }

        // GET: /Customer/Update?{customer_id}
        public async Task<IActionResult> Update(Guid customer_id)
        {
            var customer = await _customerService.GetById(customer_id);
            if(customer == null)
            {
                return RedirectToAction("Error", "Shared");
            }

            var customerViewModel = new CustomerViewModel
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                AccountID = customer.AccountID,
            };
            return View(customerViewModel);
        }

        // POST: /Customer/Update?{customer_id}
        [HttpPost]
        public async Task<IActionResult> Update(Guid customer_id, CustomerUpdateDto customer)
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
                    await _customerService.UpdateAsync(customer_id, customer);
                    TempData["success"] = "Thay đổi thông tin khách hàng " + customer_id + " thành công.";
                    return RedirectToAction("Index");
            }
            TempData["error"] = "Không tìm thấy khách hàng !!";
            return View();
        }

        // POST: /Customer/Delete?{customer_id}
        public async Task<IActionResult> Delete(Guid customer_id)
        {
            await _customerService.DeleteAsync(customer_id);
            TempData["success"] = "Đã xóa khách hàng " + customer_id;
            return RedirectToAction("Index");
        }
    }
}
