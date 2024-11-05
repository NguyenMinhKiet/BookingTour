using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception($"Employee with id {id} not found.");

            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<String> GetNameByIdAsync(int id)
        {
            var employee = await _context.Employees
                .Where(c=>c.employee_id == id)
                .Select(e=> e.first_name + e.last_name)
                .FirstOrDefaultAsync();

            return employee ?? "Không tìm thấy tên nhân viên";
        }

        public async Task<String> GetPositionByIdAsync(int id)
        {
            var employee = await _context.Employees
                .Where(c => c.employee_id == id)
                .Select(e => e.position)
                .FirstOrDefaultAsync();


            if(employee == 2)
            {
                return "Hướng dẫn viên";
            }

            else if (employee == 3)
            {
                return "Tài xế";
            }
            else
            {
                return "Nhân viên chưa được phân chức vụ";
            }

        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
