using Application.DTOs.RoleDTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RoleController(UserManager<Account> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found!";
                return RedirectToAction("Index");
            }

            var roles = await _roleManager.Roles.ToListAsync();
            var currentRole = await _userManager.GetRolesAsync(user);

            var model = new RoleChangeViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                CurrentRole = currentRole.FirstOrDefault(),
                Roles = roles.Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name,
                    Selected = currentRole.Contains(r.Name)
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRole(RoleChangeViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = "User không tồn tại";
                return RedirectToAction("Index", "Account");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            // Xoá các role cũ của user
            foreach (var role in currentRoles)
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }

            // Thêm role mới
            if (!string.IsNullOrEmpty(model.CurrentRole))
            {
                await _userManager.AddToRoleAsync(user, model.CurrentRole);
            }

            TempData["NotificationType"] = "success";
            TempData["NotificationTitle"] = "Thành công!";
            TempData["NotificationMessage"] = "Cập nhật role thành công";
            return RedirectToAction("Index","Account");
        }



    }
}
