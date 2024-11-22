using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Account> _userManager;
        public CustomerRepository(ApplicationDbContext context, UserManager<Account> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var customer = await GetByIdAsync(id);
            if(customer == null)
            {
                throw new Exception($"Customer with id {id} not found.");
            }
            _context.Customers.Remove(customer);
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid customer_id)
        {
            return await _context.Customers.FindAsync(customer_id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

        }


    }
}
