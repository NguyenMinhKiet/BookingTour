using Domain.Entities;
using Domain.Entities.Location;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly ApplicationDbContext _context;

        public DestinationRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Destination destination)
        {
            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destinations.ToListAsync();
        }

        public async Task<Destination> GetByIdAsync(Guid id)
        {
            return await _context.Destinations.FindAsync(id);
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Destinations.Update(destination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var destinnation = await GetByIdAsync(id);
            if (destinnation == null)
            {
                throw new Exception($"Customer with id {id} not found.");
            }
            _context.Destinations.Remove(destinnation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Destination>> GetByCategoryAsync(string Category)
        {
            return await _context.Destinations
                .Where(x => EF.Functions.Like(x.Category, "%" + Category + "%")).ToListAsync();
        }

        public async Task<IEnumerable<Destination>> GetByCityAsync(string City)
        {
            return await _context.Destinations
                .Where(x => EF.Functions.Like(x.City, "%" + City + "%"))  // Sử dụng LIKE để so sánh
                .ToListAsync();
        }
        public async Task<IEnumerable<Destination>> GetByCityAndCategoryAsync(string City, string Category)
        {
            return await _context.Destinations
                .Where(x => EF.Functions.Like(x.City, "%" + City + "%") && EF.Functions.Like(x.Category, "%" + Category + "%"))  // Sử dụng LIKE cho cả City và Category
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetCategory(string City)
        {
            return await _context.Destinations
                .Where(x => EF.Functions.Like(x.City,"%" +City +"%"))  // Sử dụng LIKE cho City
                .Select(x => x.Category)
                .ToListAsync();
        }


    }
}
