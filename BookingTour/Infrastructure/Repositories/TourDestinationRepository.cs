using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TourDestinationRepository : ITourDestinationRepository
    {
        private readonly ApplicationDbContext _context;
        public TourDestinationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TourDestination tourDestination)
        {
            await _context.ToursDestination.AddAsync(tourDestination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid tour_id, Guid destination_id)
        {
            var tourDestination = await GetByIdAsync(tour_id,destination_id);
            if (tourDestination == null)
            {
                throw new Exception($"Tour with id {tour_id} and Destination with id {destination_id} not found.");
            }
            _context.ToursDestination.Remove(tourDestination);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TourDestination>> GetAllAsync()
        {
            return await _context.ToursDestination.ToListAsync();
        }

        public async Task<TourDestination> GetByIdAsync(Guid tour_id, Guid destination_id)
        {
            return await _context.ToursDestination.FindAsync(tour_id, destination_id);
        }

        public async Task UpdateAsync(TourDestination tourDestination)
        {
            _context.ToursDestination.Update(tourDestination);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<TourDestination>> GetByTourIdAsync(Guid TourID)
        {
            return await _context.ToursDestination.Where(x => x.TourID == TourID).ToListAsync();
        }
    }
}
