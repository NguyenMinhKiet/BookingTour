
using Application.DTOs.AccountDTOs;
using Application.DTOs.CustomerDTOs;
using Application.DTOs.EmployeeDTOs;
using Domain.Entities;
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
        public Task<string> GeneratePasswordResetTokenAsync(string email);
        public Task<IdentityResult> UpdateUserProfileAsync(Guid UserID, string Phone);
        public Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);

        public Task<IEnumerable<AccountWithRolesViewModel>> GetAllAccountWithRolesAsync();

        public Task<Guid> GetLoginUserId();
    }
}
