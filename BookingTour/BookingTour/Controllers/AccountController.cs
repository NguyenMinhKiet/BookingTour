using Application.Services_Interface;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

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
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }

                return View(model);
            }

            // GET: /Account/Logout
            public async Task<IActionResult> Logout()
            {
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
                        return RedirectToAction(nameof(Index), "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        Console.WriteLine(error.Description);
                    }
                }

                return View(model);
            }

            // GET: /Account/AccessDenied
            public IActionResult AccessDenied()
            {
                return View();
            }

            // Phương thức hỗ trợ chuyển hướng sau khi đăng nhập
            private IActionResult RedirectToLocal(string returnUrl)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
        }
    }

