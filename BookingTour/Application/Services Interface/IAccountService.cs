
using Application.DTOs.AccountDTOs;
using Application.DTOs.CustomerDTOs;
using Application.DTOs.EmployeeDTOs;
using Microsoft.AspNetCore.Identity;
namespace Application.Services_Interface
{
    public interface IAccountService
    {
        public Task<AccountCreationResult> CreateUserAsync(CustomerCreationDto accountDto);
        public Task<AccountCreationResult> CreateUserAsync(EmployeeCreationDto accountDto);
        public Task<IdentityResult> RegisterAsync(RegisterModelDto model);
        public Task<SignInResult> LoginAsync(LoginModelDto model);
        public Task LogoutAsync();
        public Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
        public Task<string> GeneratePasswordResetTokenAsync(string email);
        public Task<IdentityResult> ResetPasswordAsync(string email, string token, string newPassword);
        public Task<IdentityResult> UpdateUserProfileAsync(string userId, UpdateProfileModel model);
        public Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
    }
}
