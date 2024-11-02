using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var customers = _db.Customers.ToList();
            return View(customers);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                TempData["success"] = "Thêm khách hàng mới thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thêm khách hàng mới thất bại !!";
            return View();
        }

        public IActionResult Update(int customer_id)
        {
            Customer? customer = _db.Customers.FirstOrDefault(i => i.customer_id == customer_id);
            if(customer == null)
            {
                return RedirectToAction("Error", "Shared");
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if(ModelState.IsValid)
            {
                var customerData = _db.Customers.Find(customer.customer_id);

                if(customerData != null)
                {
                    _db.Customers.Entry(customerData).CurrentValues.SetValues(customer);
                    _db.SaveChanges();
                    TempData["success"] = "Thay đổi thông tin khách hàng " + customer.customer_id + " thành công.";
                    return RedirectToAction("Index");
                }
                TempData["error"] = "Thay đổi thông tin khách hàng" + customer.customer_id + " thất bại !!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Không tìm thấy khách hàng !!";
            return View(customer);
        }

        public IActionResult Delete(int customer_id)
        {
            Customer? customer = _db.Customers.FirstOrDefault(c=>c.customer_id == customer_id);
            if (customer is not null)
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
                TempData["success"] = "Đã xóa khách hàng " + customer_id;
                return RedirectToAction("Index");
            }
            TempData["error"] = "Không tìm thấy khách hàng !!";
            return View();
        }
    }
}
