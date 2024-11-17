using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TourEmployeeRepository : ITourEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public TourEmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TourEmployee tourEmployee)
        {
            await _context.ToursEmployee.AddAsync(tourEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid tour_id, Guid employee_id)
        {
            var tourEmployee = await GetByIdAsync(tour_id, employee_id);
            if (tourEmployee == null)
            {
                throw new Exception($"Tour with id {tour_id} and Employee with id {employee_id} not found.");
            }
            _context.ToursEmployee.Remove(tourEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TourEmployee>> GetAllAsync()
        {
            return await _context.ToursEmployee.ToListAsync();
        }

        public async Task<TourEmployee> GetByIdAsync(Guid tour_id, Guid employee_id)
        {
            return await _context.ToursEmployee.FindAsync(tour_id, employee_id);
        }

        public Task<TourEmployee> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TourEmployee tourEmployee)
        {
            _context.ToursEmployee.Update(tourEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TourEmployee>> GetByTourIdAsync(Guid TourID)
        {
            return await _context.ToursEmployee.Where(x => x.TourID == TourID).ToListAsync();
        }
    }
}
