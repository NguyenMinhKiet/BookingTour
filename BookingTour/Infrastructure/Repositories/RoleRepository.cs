//using Domain.Entities;
//using Domain.Repositories;
//using Infrastructure.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//namespace Infrastructure.Repositories
//{
//    public class RoleRepository : IRoleRepository
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly RoleManager<Role> _roleManager;
//        public RoleRepository(ApplicationDbContext context, RoleManager<Role> roleManager)
//        {
//            _context = context;
//            _roleManager = roleManager;
//        }
//        public async Task AddAsync(Role role)
//        {
//            _context.Roles.Add(role);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int RoleID)
//        {
//            var role = _context.role;
//            if(role != null)
//            {
//                 _context.Roles.Remove(role);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<IEnumerable<Role>> GetAllAsync()
//        {
//            return await _context.Roles.ToListAsync();
//        }

//        public async Task<Role> GetByIdAsync(int RoleID)
//        {
//            return await _context.Roles.FindAsync(RoleID);
//        }

//        public async Task UpdateAsync(Role role)
//        {
//            _context.Roles.Update(role);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
