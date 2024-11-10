using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Role tour)
        {
            await _context.Roles.AddAsync(tour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tour = await GetByIdAsync(id);
            if (tour == null)
            {
                throw new Exception($"Tour with id {id} not found.");
            }
            _context.Roles.Remove(tour);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(Guid tour_id)
        {
            return await _context.Roles.FindAsync(tour_id);
        }

        public async Task UpdateAsync(Role tour)
        {
            _context.Roles.Update(tour);
            await _context.SaveChangesAsync();
        }
    }
}
