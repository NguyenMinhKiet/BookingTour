﻿using Application.DTOs.AccountDTOs;
using Application.DTOs.CustomerDTOs;
using Application.DTOs.EmployeeDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly RoleManager<Role> _roleManager;


        public AccountService(UserManager<Account> userManager,
                              SignInManager<Account> signInManager,
                              RoleManager<Role> roleManager
                              )
            
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterModelDto model)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                // Thêm lỗi nếu email đã tồn tại
                return IdentityResult.Failed(new IdentityError
                {
                    Description = "Email đã tồn tại."
                });
            }

            
            var user = new Account
            {
                UserName = model.Username.Trim(),
                Email = model.Email.Trim(),
                Phone = model.Phone.Trim(),
                Password = model.Password.Trim(),
                isActive = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Gán role mặc định nếu cần
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result;
            }

        public async Task<AccountCreationResult> CreateUserAsync(CustomerCreationDto model)
        {
            var defaultPassword = "Example123".Trim();
            var accountDto = new Account
            {
                UserName = model.Email.Trim(),
                Email = model.Email.Trim(),
                Phone = model.Phone.Trim(),
                Password = defaultPassword,
                isActive = true
            };
            var result = await _userManager.CreateAsync(accountDto, defaultPassword);

            if (result.Succeeded)
            {
                // Gán role mặc định nếu cần
                await _userManager.AddToRoleAsync(accountDto, "User");
            }

            return new AccountCreationResult
            {
                Result = result,
                UserId = result.Succeeded ? accountDto.Id : null
            };
        }

        public async Task<AccountCreationResult> CreateUserAsync(EmployeeCreationDto model)
        {
            var defaultPassword = "Example123";
            var accountDto = new Account
            {
                UserName = model.Email,
                Email = model.Email,
                Phone = model.Phone,
                Password = defaultPassword,
                isActive = true
            };

            // Tạo tài khoản với mật khẩu
            var result = await _userManager.CreateAsync(accountDto, defaultPassword);


            // Nếu thành công, thêm UserId vào AccountCreationDto
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(accountDto, "Employee");
                model.AccountID = accountDto.Id;
            }

            return new AccountCreationResult
            {
                Result = result,
                UserId = result.Succeeded ? accountDto.Id : null
            };
        }
        public async Task<SignInResult> LoginAsync(LoginModelDto model)
        {
            return await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return IdentityResult.Failed();

            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return null;

            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return IdentityResult.Failed();

            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }


        public async Task<IdentityResult> UpdateUserProfileAsync(string userId, UpdateProfileModel model)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return IdentityResult.Failed();

            user.Email = model.Email;
            user.Phone = model.Phone;

            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return IdentityResult.Failed();

            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<IEnumerable<AccountWithRolesViewModel>> GetAllAccountWithRolesAsync()
        {
            // Lấy danh sách tất cả người dùng
            var users = await _userManager.Users.ToListAsync();

            // Tạo danh sách kết quả kèm theo vai trò
            var userWithRoles = new List<AccountWithRolesViewModel>();

            foreach (var user in users)
            {
                // Lấy danh sách vai trò của từng user
                var roles = await _userManager.GetRolesAsync(user);

                // Thêm vào danh sách kết quả
                userWithRoles.Add(new AccountWithRolesViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Phone = user.Phone,
                    Password = user.Password,
                    isActive = user.isActive,
                    
                    Roles = roles.ToList() // Convert sang List<string> nếu cần
                });
            }

            return userWithRoles;
        }


    }



}