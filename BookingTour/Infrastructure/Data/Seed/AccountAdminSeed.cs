using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seed
{
    public class AccountAdminSeed
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<Account> userManager)
        {

            var adminUser = new Account
            {
                UserName = "admin",
                Email = "nguyenminhkiet642002@gmail.com",
                Password = "Kiet123",
                Phone = "0932667135",
                isActive = true,
            };

            var user = await userManager.FindByEmailAsync(adminUser.Email);
            if (user == null)
            {
                var result = await userManager.CreateAsync(adminUser, "Kiet123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
