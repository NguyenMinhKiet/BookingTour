using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var employees = _db.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (employee.phone.Length != 10)
            {
                ModelState.AddModelError("phone", "Số điện thoại phải có 10 kí tự số !! ");
            }
            if (ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                _db.SaveChanges();
                TempData["success"] = "Thêm nhân viên mới thành công.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Thêm nhân viên thất bại !!";
            return View();
        }

        
        public IActionResult Update(int employee_id)
        {
            
            Employee? employee = _db.Employees.FirstOrDefault(i=>i.employee_id == employee_id);
            if (employee == null)
            {
                return RedirectToAction("Error", "Shared");
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            if (employee.phone.Length != 10)
            {
                ModelState.AddModelError("phone", "Số điện thoại phải có 10 kí tự số !! ");
            }
            if (ModelState.IsValid)
            {
                var employeeData = _db.Employees.Find(employee.employee_id);
                if (employeeData != null)
                {
                    _db.Employees.Entry(employeeData).CurrentValues.SetValues(employee);
                    _db.SaveChanges();
                    TempData["success"] = "Cập nhật thông tin nhân viên " + employee.employee_id + " thành công.";
                    return RedirectToAction("Index");
                }
                TempData["error"] = "Cập nhật thông tin nhân viên " + employee.employee_id + " thất bại !!";
                return RedirectToAction("Index");

            }
            TempData["error"] = "Không tìm thấy nhân viên !!";
            return View(employee);
        }

        public IActionResult Delete(int employee_id)
        {
            Employee? employee = _db.Employees.FirstOrDefault(e => e.employee_id == employee_id);
            if(employee is not null)
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
                TempData["success"] = "Đã xóa nhân viên " + employee_id;
                return RedirectToAction("Index");
            }
            TempData["error"] = "Không tìm thấy nhân viên !!";
            return View();
        }
    }
}
