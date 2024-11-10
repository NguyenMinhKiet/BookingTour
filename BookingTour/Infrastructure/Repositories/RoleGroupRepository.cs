//using Domain.Entities;
//using Domain.Repositories;
//using Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Repositories
//{
//    public class RoleGroupRepository : IRoleGroupRepository
//    {
//        private readonly ApplicationDbContext _context;
//        public RoleGroupRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public async Task AddAsync(RoleGroup role)
//        {
//            _context.RoleGroups.Add(role);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(Guid RoleID)
//        {
//            var g = await _context.RoleGroups.FirstOrDefaultAsync(g => g.RoleID == RoleID);
//            if (g != null)
//            {
//                _context.RoleGroups.Remove(g);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<IEnumerable<RoleGroup>> GetAllAsync()
//        {
//            return await _context.RoleGroups.ToListAsync();
//        }

//        public async Task<RoleGroup> GetByIdAsync(Guid RoleID)
//        {
//            return await _context.RoleGroups.FindAsync(RoleID);
//        }

//        public async Task UpdateAsync(RoleGroup role)
//        {
//            _context.RoleGroups.Update(role);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
