using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationDbContext _context;
        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Tour tour)
        {
            await _context.Tours.AddAsync(tour);
            

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tour = await GetByIdAsync(id);
            if (tour == null)
            {
                throw new Exception($"Tour with id {id} not found.");
            }
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tour>> GetAllAsync()
        {
            return await _context.Tours.ToListAsync();
        }

        public async Task<Tour> GetByIdAsync(Guid tour_id)
        {
            return await _context.Tours.FindAsync(tour_id);
        }

       

        public async Task UpdateAsync(Tour tour)
        {
            _context.Tours.Update(tour);
            await _context.SaveChangesAsync();
        }
    }
}
