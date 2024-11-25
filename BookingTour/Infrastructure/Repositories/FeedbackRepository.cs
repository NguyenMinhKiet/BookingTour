using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;
        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<Feedback> GetByIdAsync(Guid id)
        {
            return await _context.Feedbacks.FindAsync(id);
        }

        public async Task UpdateAsync(Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var feedback = await GetByIdAsync(id);
            if (feedback == null)
            {
                throw new Exception($"Feedback with id {id} not found.");
            }
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Feedback>> GetByTourID(Guid TourID)
        {

            var result = await _context.Feedbacks
                .Where(x => x.TourID == TourID).ToListAsync();

            return result;
        }

        public async Task<List<Feedback>> GetByTourIDAndCustomerID(Guid TourID, Guid CustomerID)
        {
            return await _context.Feedbacks.Where(x=>x.TourID == TourID && x.CustomerID == CustomerID)
                .Include(x=>x.Customer)
                .Include(x=>x.Tour)
                .ToListAsync();
        }
    }
}
