using Application.DTOs.AccountDTOs;
using Application.DTOs.CustomerDTOs;
using Application.DTOs.EmployeeDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Admin.Models;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private UserManager<Account> _userManager;

        public AccountController(IAccountService accountService, UserManager<Account> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
        }


        [Authorize(Policy = "account-view")]
        public async Task<IActionResult> Index()
        {
            var listAccount = await _accountService.GetAllAccountWithRolesAsync();
            var listView = new List<AccountViewModel>();

            foreach(var account in listAccount)
            {
                var acc = new AccountViewModel
                {
                    Id = account.Id,
                    Username = account.UserName,
                    Password = account.Password,
                    Email = account.Email,
                    Phone = account.Phone,
                    Roles = account.Roles,
                    isActive = account.isActive
                };
                listView.Add(acc);
            }
            
            return View(listView);
        }

        [Authorize(Policy = "account-add")]
        public async Task<IActionResult> Register()
        {
            var employee = new CustomerCreationDto
            {
                FirstName = "emailmoin111e@gmail.com",
                LastName = "1231231",
                Address = "123123",
                Email = "emailmoi12312311111232@gmail.com",
                Phone = "123123",
            };

            var createAccount = await _accountService.CreateUserAsync(employee);

            if (createAccount.Result.Succeeded)
            {
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = "Thêm thành công";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = string.Join(", ", createAccount.Result.Errors.Select(e => e.Description));
            return View();
        }

        public async Task<IActionResult> BlockUser(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    TempData["NotificationType"] = "danger";
                    TempData["NotificationTitle"] = "Thất bại!";
                    TempData["NotificationMessage"] = "Không tìm thấy tài khoản!";
                    return RedirectToAction("Index");
                }

                if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.Now)
                {
                    user.LockoutEnd = null; // Mở khóa tài khoản
                    user.isActive = true;
                    await _userManager.UpdateAsync(user);
                    TempData["NotificationType"] = "success";
                    TempData["NotificationTitle"] = "Thành công!";
                    TempData["NotificationMessage"] = $"Đã mở khóa tài khoản {user.Email}";
                }
                else
                {
                    user.LockoutEnd = DateTimeOffset.UtcNow.AddYears(100); // Khóa tài khoản
                    user.isActive = false;
                    await _userManager.UpdateAsync(user);
                    TempData["NotificationType"] = "success";
                    TempData["NotificationTitle"] = "Thành công!";
                    TempData["NotificationMessage"] = $"Đã khóa tài khoản {user.Email}";
                }

                return RedirectToAction("Index"); // Sau khi xử lý xong, redirect lại trang Index
            }
            catch (Exception ex)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Lỗi hệ thống";
                TempData["NotificationMessage"] = $"Có lỗi xảy ra: {ex.Message}";
                return RedirectToAction("Index");
            }
        }


    }



}
