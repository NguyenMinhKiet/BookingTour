using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthorizedRepository : IAuthorizedRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorizedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Authorized Authorized)
        {
            await _context.Authorizeds.AddAsync(Authorized);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var Authorized = await GetByIdAsync(id);
            if (Authorized == null)
            {
                throw new Exception($"Authorized with id {id} not found.");
            }
            _context.Authorizeds.Remove(Authorized);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Authorized>> GetAllAsync()
        {
            return await _context.Authorizeds.ToListAsync();
        }

        public async Task<Authorized> GetByIdAsync(Guid id)
        {
            return await _context.Authorizeds.FindAsync(id);
        }

        public async Task UpdateAsync(Authorized Authorized)
        {
            _context.Authorizeds.Update(Authorized);
            await _context.SaveChangesAsync();
        }
    }
}
