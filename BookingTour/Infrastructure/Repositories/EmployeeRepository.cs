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

        public async Task DeleteAsync(Guid id)
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

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<String> GetNameByIdAsync(Guid id)
        {
            var employee = await _context.Employees
                .Where(c=>c.EmployeeID == id)
                .Select(e=> e.FirstName + e.LastName)
                .FirstOrDefaultAsync();

            return employee ?? "Không tìm thấy tên nhân viên";
        }

        public async Task<String> GetPositionByIdAsync(Guid id)
        {
            var position = await _context.Employees
                .Where(c => c.EmployeeID == id)
                .Select(e => e.Position)
                .FirstOrDefaultAsync();

            return position;

        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
