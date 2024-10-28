using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourDuLich.Domain.Entities;
using TourDuLich.Infrastructure.DataAccess.Context;

namespace TourDuLich.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly BookingTourDbContext _bookingTourDbContext;

        public EmployeeController(BookingTourDbContext bookingTourDbContext)
        {
            _bookingTourDbContext = bookingTourDbContext;
        }

        public IActionResult Index()
        {
            var employees = _bookingTourDbContext.Employees.ToList();


            return View(employees);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _bookingTourDbContext.Employees.Add(employee);
                _bookingTourDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = _bookingTourDbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.employee_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookingTourDbContext.Update(employee);
                _bookingTourDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int id)
        {
            var employee = _bookingTourDbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _bookingTourDbContext.Employees.Find(id);
            if (employee != null)
            {
                _bookingTourDbContext.Employees.Remove(employee);
                _bookingTourDbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
