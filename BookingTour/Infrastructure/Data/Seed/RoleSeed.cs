using Domain.Entities;
using Infrastructure.Static;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seed
{
    public class RoleSeed
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleSeed(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            // Get permissions from static class
            var adminPermissions = PERMISSIONS.GetAllPermisstions();
            var employeePermissions = PERMISSIONS.GetEmployeePermisstions();
            var userPermissions = PERMISSIONS.GetCustomerPermisstions();

            await CreateRoleAsync("Admin", adminPermissions);
            await CreateRoleAsync("Employee", employeePermissions);
            await CreateRoleAsync("User", userPermissions);
        }

        private async Task CreateRoleAsync(string roleName, Dictionary<string, string> permissions)
        {
            // Check if the role already exists
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                // Create new role
                var role = new Role(roleName, $"{roleName} Role");

                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    // Add claims (permissions)
                    foreach (var permission in permissions.Keys)
                    {
                        var claim = new System.Security.Claims.Claim("permission", permission);
                        await _roleManager.AddClaimAsync(role, claim);
                    }
                }
                else
                {
                    // Handle failure to create role
                    Console.WriteLine($"Failed to create role {roleName}");
                }
            }
        }
    }
}
