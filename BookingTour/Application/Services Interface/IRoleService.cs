using Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace Application.Services_Interface
{
    public interface IRoleService
    {
        public Task<List<Role>> GetAllRolesAsync();
        public Task<IList<string>> GetUserRolesAsync(Account user);
        public Task<IList<Account>> GetUsersInRoleAsync(string roleName);
        public Task<bool> CreateRoleAsync(string roleName, string roleDescription);
        public Task<bool> DeleteRoleAsync(string roleName);
        public Task<bool> UpdateRoleNameAsync(string oldRoleName, string newRoleName);
        public Task<bool> AssignUserToRoleAsync(Account user, string role);
        public Task<bool> RemoveUserFromRoleAsync(Account user, string roleName);
        public Task<bool> IsUserInRoleAsync(Account user, string roleName);
    }
}
