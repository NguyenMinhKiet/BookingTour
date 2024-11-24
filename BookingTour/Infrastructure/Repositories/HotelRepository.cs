using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;
        public HotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Hotel Hotel)
        {
            await _context.Hotels.AddAsync(Hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid HotelID)
        {
            var hotel = await GetByIdAsync(HotelID);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync(string? City)
        {
            if (!string.IsNullOrEmpty(City))
            {
                var list = await _context.Hotels
                                .Where(x => x.City.ToLower() == City.ToLower())
                                .ToListAsync();
                return list;

            }
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetByIdAsync(Guid Hotel)
        {
            return await _context.Hotels.FindAsync(Hotel);
        }

        public async Task UpdateAsync(Hotel Hotel)
        {
            _context.Hotels.Update(Hotel);
            await _context.SaveChangesAsync();
        }
    }
}
