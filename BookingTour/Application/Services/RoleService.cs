using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RoleService(UserManager<Account> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IList<string>> GetUserRolesAsync(Account user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IList<Account>> GetUsersInRoleAsync(string roleName)
        {
            return await _userManager.GetUsersInRoleAsync(roleName);
        }

        public async Task<bool> CreateRoleAsync(string roleName, string roleDescription)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                return false; // Vai trò đã tồn tại

            var result = await _roleManager.CreateAsync(new Role(roleName, roleDescription));
            return result.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) return false;

            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> UpdateRoleNameAsync(string oldRoleName, string newRoleName)
        {
            var role = await _roleManager.FindByNameAsync(oldRoleName);
            if (role == null) return false;

            role.Name = newRoleName;
            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded;
        }



        public async Task<bool> AssignUserToRoleAsync(Account user, string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new Role(role,"Cần Thêm Mô Tả"));
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }

        public async Task<bool> RemoveUserFromRoleAsync(Account user, string roleName)
        {
            if (!await _userManager.IsInRoleAsync(user, roleName)) return false;

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<bool> IsUserInRoleAsync(Account user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

    }

}
