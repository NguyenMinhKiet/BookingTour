using Application.Services_Interface;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Application.DTOs.AccountDTOs;

namespace Presentation.Controllers
{
        public class AccountController : Controller
        {
            private readonly SignInManager<Account> _signInManager;
            private readonly UserManager<Account> _userManager;
            private readonly IAccountService _accountService;

            public AccountController(SignInManager<Account> signInManager,
                                     UserManager<Account> userManager,
                                     IAccountService accountService)
            {
                _signInManager = signInManager;
                _userManager = userManager;
                _accountService = accountService;
            }

            // GET: /Account/Login
            public IActionResult Login()
            {
                return View();
            }

            // POST: /Account/Login
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
            {
                returnUrl ??= Url.Content("~/");

                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {

                        // Lấy thông tin người dùng
                        var user = await _userManager.FindByNameAsync(model.UserName);
                        if (user != null)
                        {
                            // Lưu tên người dùng vào Session
                            HttpContext.Session.SetString("UserName", user.UserName);

                            // Lấy danh sách quyền/role của user
                            var roles = await _userManager.GetRolesAsync(user);

                            // Kiểm tra quyền và điều hướng
                            if (roles.Contains("Admin"))
                            {
                                TempData["NotificationType"] = "success";
                                TempData["NotificationTitle"] = "Đăng nhập thành công!";
                                TempData["NotificationMessage"] = $"Xin chào Admin {user.UserName}!";

                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                            }
                            else
                            {
                                TempData["NotificationType"] = "success";
                                TempData["NotificationTitle"] = "Đăng nhập thành công!";
                                TempData["NotificationMessage"] = $"Xin chào {user.UserName}!";

                            return RedirectToAction("Index", "Home");
                            }
                        
                        }
                        
                    }
                    else
                    {
                        TempData["NotificationType"] = "danger";
                        TempData["NotificationTitle"] = "Đăng nhập thất bại!";
                        TempData["NotificationMessage"] = "Tài khoản bị khóa hoặc Mật khẩu không đúng !";

                    return View(model);
                    }
                }

                return View(model);
            }

            // GET: /Account/Logout
            public async Task<IActionResult> Logout()
            {
            HttpContext.Session.Remove("UserName");
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
            }

            // GET: /Account/Register
            public IActionResult Register()
            {
                return View();
            }

            // POST: /Account/Register
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = new Account 
                    { 
                        UserName = model.UserName, 
                        Email = model.Email,
                        Phone = model.Phone,
                        Password = model.Password,
                        isActive = true
                    };
                // Kiểm tra xem model.Password và model.ConfirmPassword có giá trị không
                var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        TempData["NotificationType"] = "success";
                        TempData["NotificationTitle"] = "Tạo tài khoản thành công!";
                        TempData["NotificationMessage"] = $"Xin chào {user.UserName}!";
                        return RedirectToAction(nameof(Index), "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Tài khoản đã tồn tại vui lòng đăng nhập!");
                        return RedirectToAction("Login");
                    }
                }
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Đăng ký thất bại!";
                TempData["NotificationMessage"] = "Dữ liệu nhập không hợp lệ";
                return View(model);
            }

            // GET: /Account/AccessDenied
            public IActionResult AccessDenied()
            {
                return View();
            }

        [HttpGet]
        public IActionResult ChangePassword(string userId)
        {
            var model = new ChangePasswordViewModel
            {
                userId = userId
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(string userId, ChangePasswordViewModel model)
        {
            
            if(ModelState.IsValid)
            {
                var account = await _userManager.FindByIdAsync(userId);
                if (account != null)
                {
                    account.Password = model.Password;
                    await _userManager.UpdateAsync(account);

                    TempData["NotificationType"] = "success";
                    TempData["NotificationTitle"] = "Thành công!";
                    TempData["NotificationMessage"] = $"Thay đổi mật khẩu thành công!";

                    return RedirectToAction("Index", "Home");
                }
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy tài khoản!";
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }

        
    }
}

