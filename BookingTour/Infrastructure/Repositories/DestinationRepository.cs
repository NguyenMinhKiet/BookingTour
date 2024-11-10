using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
