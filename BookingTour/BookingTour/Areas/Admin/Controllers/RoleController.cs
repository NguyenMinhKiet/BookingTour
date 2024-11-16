using Application.DTOs.RoleDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Infrastructure.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.Areas.Admin.Models;
using System.Security.Claims;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RoleController(IRoleService roleService,UserManager<Account> userManager, RoleManager<Role> roleManager)
        {
            _roleService = roleService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var listRoleClaimsViewModel = new List<RoleClaimsViewModel>();
            foreach (var role in roles)
            {
                var claims = await _roleManager.GetClaimsAsync(role);
                var listClaimViewModel = new List<ClaimViewModel>();
                foreach (var claim in claims)
                {
                    var claimViewModel = new ClaimViewModel
                    {
                        Type = claim.Type,
                        Value = claim.Value,
                        Selected = false,
                    };
                    listClaimViewModel.Add(claimViewModel);
                }
                var roleClaimsViewModel = new RoleClaimsViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    Claims = listClaimViewModel
                };
                listRoleClaimsViewModel.Add(roleClaimsViewModel);
            }

            return View(listRoleClaimsViewModel);
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


        public async Task<IActionResult> UpdateRoleClaims(string roleId)
        {
            var ClaimType = "permission";
            var permissionList = PERMISSIONS.GetAllPermisstions();
            var PermissionListViewModel = new List<ClaimViewModel>();
            foreach (var permission in permissionList)
            {
                var claim = new ClaimViewModel
                {
                    Type = ClaimType, 
                    Value = permission.Key,
                    Description = permission.Value,
                    Selected = false
                    
                };
                PermissionListViewModel.Add(claim);
            }

            var role = await _roleManager.FindByIdAsync(roleId);
                var claims = await _roleManager.GetClaimsAsync(role);
                var listClaimViewModel = new List<ClaimViewModel>();

            // Đánh dấu Selected dựa trên các Claims đã tồn tại
            foreach (var permissionClaim in PermissionListViewModel)
            {
                foreach (var claim in claims)
                {
                    if (string.Equals(claim.Type, permissionClaim.Type, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(claim.Value, permissionClaim.Value, StringComparison.OrdinalIgnoreCase))
                        {
                            permissionClaim.Selected = true; // Đánh dấu nếu tồn tại trong Claims
                        }
                }
            }

            var roleClaimsViewModel = new RoleClaimsViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                Claims = PermissionListViewModel
            };
            return View(roleClaimsViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoleClaims(string roleId, RoleClaimsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleService.GetByIdAsync(roleId);
                if (role == null)
                {
                    TempData["NotificationType"] = "danger";
                    TempData["NotificationTitle"] = "Thất bại!";
                    TempData["NotificationMessage"] = "Không tìm thấy role";
                    return RedirectToAction("UpdateRoleClaims", new { roleId = roleId });
                }

                // Cập nhật claims
                var result = await UpdateRoleClaimsAsync(role, model);

                if (result)
                {
                    // Thông báo thành công
                    TempData["NotificationType"] = "success";
                    TempData["NotificationTitle"] = "Thành công!";
                    TempData["NotificationMessage"] = "Cập nhật quyền thành công";
                    // Quay lại trang UpdateRoleClaims sau khi thành công
                    return RedirectToAction("UpdateRoleClaims", new { roleId = roleId });
                }
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = "Không thể cập nhật quyền";
                return RedirectToAction("UpdateRoleClaims", new { roleId = roleId });
            }

            // Nếu ModelState không hợp lệ, hiển thị thông báo lỗi và quay lại trang UpdateRoleClaims
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu không hợp lệ";

            return RedirectToAction("UpdateRoleClaims", new { roleId = roleId });
        }



        private async Task<bool> UpdateRoleClaimsAsync(Role role, RoleClaimsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Lấy danh sách các claims hiện tại của role
                var currentClaims = await _roleManager.GetClaimsAsync(role);

                // Xóa tất cả các claims hiện tại
                foreach (var claim in currentClaims)
                {
                    await _roleManager.RemoveClaimAsync(role, claim);
                }

                // Thêm các claims mới đã được chọn từ model
                foreach (var claim in model.Claims.Where(c => c.Selected))
                {
                    var newClaim = new Claim(claim.Type, claim.Value);
                    await _roleManager.AddClaimAsync(role, newClaim);
                }
                return true;
            }
            return false;
        }

        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if(role != null)
            {
                var result = await _roleService.DeleteRoleAsync(role.Id);
                if (result)
                {
                    TempData["NotificationType"] = "success";
                    TempData["NotificationTitle"] = "Thành Công!";
                    TempData["NotificationMessage"] = "Xóa Role thành công!";
                    return RedirectToAction("Index");
                }
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = "Không thể xóa Role";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Lỗi: Role không tồn tại";
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleService.CreateRoleAsync(model.Name,model.Name + " Role");
                if (result)
                {
                    TempData["NotificationType"] = "success";
                    TempData["NotificationTitle"] = "Thành công!";
                    TempData["NotificationMessage"] = $"Thêm Role {model.Name} thành công!";
                    return RedirectToAction("Index");
                }
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Role {model.Name} đã tồn tại!";
                return View(model);
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = "Dữ liệu không hợp lệ";
            return View(model);
        }

        public async Task<IActionResult> CreateClaim(string roleId)
        {
            var role = await _roleService.GetByIdAsync(roleId);
            if(role == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy role";
                return RedirectToAction("UpdateRoleClaims", new { roleId = roleId});
            }
            var claimViewModel = new ClaimViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                Selected = false
            };
            return View(claimViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateClaim(string roleId, ClaimViewModel model)
        {

            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role != null)
                {
                    var claim = new Claim(model.Type, model.Value);
                    var result = await _roleManager.AddClaimAsync(role, claim);
                    if (result.Succeeded)
                    {
                        TempData["NotificationType"] = "success";
                        TempData["NotificationTitle"] = "Thành công!";
                        TempData["NotificationMessage"] = $"Đã thêm {claim.Value} vào {role.Name}";
                        return RedirectToAction("UpdateRoleClaims", new { roleId = role.Id });
                    }
                    else
                    {
                        TempData["NotificationType"] = "danger";
                        TempData["NotificationTitle"] = "Thất bại!";
                        TempData["NotificationMessage"] = $"{claim.Value} đã tồn tại trong {role.Name}";
                        return View(model);
                    }
                }
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy role";
                return RedirectToAction("Index");
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Dữ liệu không hợp lệ";
            return View(model);

        }
    }
}
