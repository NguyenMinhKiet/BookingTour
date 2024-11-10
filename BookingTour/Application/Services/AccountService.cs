using Application.DTOs.AccountDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Account> _userManager;
        public AccountService(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateAsync(AccountCreateDto dto, Role role)
        {
                var account = new Account
                {
                    UserName = dto.Username,
                    PasswordHash = dto.Password,
                    Email = dto.Email
                };
                var result = await _userManager.CreateAsync(account);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(account, role.Code);
                }
                return result;

        }
    }
}
