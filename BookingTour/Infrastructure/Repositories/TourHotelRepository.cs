using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TourHotelRepository : ITourHotelRepository
    {
        private readonly ApplicationDbContext _context;
        public TourHotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TourHotel TourHotel)
        {
            await _context.TourHotels.AddAsync(TourHotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid TourID, Guid HotelID)
        {
            var tourHotel =  await GetByIdAsync(TourID, HotelID);
            _context.TourHotels.Remove(tourHotel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TourHotel>> GetAllAsync()
        {
            return await _context.TourHotels.ToListAsync();
        }

        public async Task<TourHotel> GetByIdAsync(Guid TourID, Guid HotelID)
        {
            return _context.TourHotels.Where(x => x.TourID == TourID && x.HotelID == HotelID).FirstOrDefault();
        }

        public async Task<IEnumerable<TourHotel>> GetByTourID(Guid TourID)
        {
            return await _context.TourHotels.Where(x => x.TourID == TourID).ToListAsync();
        }

        public async Task UpdateAsync(TourHotel TourHotel)
        {
            _context.TourHotels.Update(TourHotel);
            await _context.SaveChangesAsync();
        }
    }
}
