using Application.DTOs.AccountDTOs;
using Application.DTOs.CustomerDTOs;
using Application.DTOs.EmployeeDTOs;
using Application.Services_Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Admin.Models;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
    }
}
