using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Account Account)
        {
            await _context.Accounts.AddAsync(Account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var Account = await GetByIdAsync(id);
            if (Account == null)
            {
                throw new Exception($"Account with id {id} not found.");
            }
            _context.Accounts.Remove(Account);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(Guid id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task UpdateAsync(Account Account)
        {
            _context.Accounts.Update(Account);
            await _context.SaveChangesAsync();
        }

        public async Task<Account> GetByEmailAsync(string email)
        {
            return await _context.Accounts.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Account> GetByPhoneAsync(string phone)
        {
            return await _context.Accounts.FirstOrDefaultAsync(c => c.Phone == phone);
        }
    }
}
