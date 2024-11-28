using Application.DTOs.RoleDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Presentation.Areas.Admin.Models;
using System.Security.Claims;

namespace Presentation.Areas.Admin.Controllers
{
    [Authorize(Policy ="RequiredAdminOrManager")]
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

        [Authorize(Policy = "role-view")]
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
            ViewData["ActivePage"] = "AccountManager";
            return View(listRoleClaimsViewModel);
        }

        [Authorize(Policy = "role-change")]
        public async Task<IActionResult> ChangeRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = "User không tồn tại";
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
            ViewData["ActivePage"] = "AccountManager";
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "role-update")]
        public async Task<IActionResult> UpdateRole(RoleChangeViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
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

        [Authorize(Policy = "role-claims-view")]
        public async Task<IActionResult> UpdateRoleClaims(string roleId)
        {
            var ClaimType = "permission";
            //var permissionList = PERMISSIONS.GetAllPermisstions();

            var role = await _roleManager.FindByIdAsync(roleId);
            if(role != null)
            {
                var permissionList = await _roleManager.GetClaimsAsync(role);
                var PermissionListViewModel = new List<ClaimViewModel>();

                foreach (var permission in permissionList)
                {
                    var data = JsonConvert.DeserializeObject<Permission>(permission.Value);
                    var claim = new ClaimViewModel
                    {
                        Type = ClaimType,
                        Value = data.Value,
                        Description = data.Description,
                        Selected = data.IsActive
                    };
                    PermissionListViewModel.Add(claim);
                }
                var roleClaimsViewModel = new RoleClaimsViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    Claims = PermissionListViewModel
                };
                ViewData["ActivePage"] = "AccountManager";
                return View(roleClaimsViewModel);
            }
            ViewData["ActivePage"] = "AccountManager";
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "role-claims-update")]
        public async Task<IActionResult> UpdateRoleClaims(Guid roleId, RoleClaimsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleService.GetByIdAsync(roleId.ToString());
                if (role == null)
                {
                    TempData["NotificationType"] = "danger";
                    TempData["NotificationTitle"] = "Thất bại!";
                    TempData["NotificationMessage"] = "Không tìm thấy role";
                    return RedirectToAction("UpdateRoleClaims", new { roleId = roleId });
                }

                // Cập nhật claims
                var result = await ReClaimsRole(role, model);

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
            return View(model);
        }

        [HttpPost]
        public async Task<bool> ReClaimsRole(Role role, RoleClaimsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var claims = await _roleManager.GetClaimsAsync(role);

                foreach (var claim in claims)
                {
                    await _roleManager.RemoveClaimAsync(role, claim);
                }

                var newClaims = model.Claims;

                foreach (var claim in newClaims)
                {
                    var permission = new Permission(claim.Value, claim.Description, claim.Selected);
                    await _roleManager.AddClaimAsync(role, new Claim(claim.Type, JsonConvert.SerializeObject(permission)));
                }
                return true;
            }
            return false;
        }


        [Authorize(Policy = "role-delete")]
        public async Task<IActionResult> Delete(Guid roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if(role != null)
            {
                var result = await _roleService.DeleteRoleAsync(role.Id.ToString());
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

        [Authorize(Policy ="role-add")]
        public IActionResult Create()
        {
            ViewData["ActivePage"] = "AccountManager";
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "role-add")]
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

        [Authorize(Policy = "role-claims-add")]
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
            ViewData["ActivePage"] = "AccountManager";
            return View(claimViewModel);
        }
        [HttpPost]
        [Authorize(Policy = "role-claims-add")]
        public async Task<IActionResult> CreateClaim(string roleId, ClaimViewModel model)
        {

            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                if (role != null)
                {

                    var existingClaim = _roleManager.GetClaimsAsync(role).Result
                        .FirstOrDefault(c => c.Value == JsonConvert.SerializeObject(new Permission(model.Value, model.Description, model.Selected)));

                    if (existingClaim != null)
                    {
                        TempData["NotificationType"] = "danger";
                        TempData["NotificationTitle"] = "Thất bại!";
                        TempData["NotificationMessage"] = $"Claim với giá trị {model.Value} đã tồn tại.";
                        return View(model);
                    }

                    var claim = new Claim(model.Type, JsonConvert.SerializeObject(new Permission(model.Value,model.Description,false)));
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
                        var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
                        TempData["NotificationType"] = "danger";
                        TempData["NotificationTitle"] = "Thất bại!";
                        TempData["NotificationMessage"] = $"Lỗi khi thêm claim: {errorMessages}";
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

        [Authorize(Policy = "role-claims-delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteClaim(string roleId,string type,string value, string description, bool isActive)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                TempData["NotificationType"] = "danger";
                TempData["NotificationTitle"] = "Thất bại!";
                TempData["NotificationMessage"] = $"Không tìm thấy role";
                return RedirectToAction("UpdateRoleClaims", new { roleId = role.Id });
            }

           var result =  await _roleManager.RemoveClaimAsync(role, new Claim(type, JsonConvert.SerializeObject(new Permission(value,description,isActive))));
            if (result.Succeeded)
            {
                TempData["NotificationType"] = "success";
                TempData["NotificationTitle"] = "Thành công!";
                TempData["NotificationMessage"] = $"Đã xóa claim thành công";
                return RedirectToAction("UpdateRoleClaims", new { roleId = role.Id });
            }
            TempData["NotificationType"] = "danger";
            TempData["NotificationTitle"] = "Thất bại!";
            TempData["NotificationMessage"] = $"Không thể xóa claim";
            return RedirectToAction("UpdateRoleClaims", new { roleId = role.Id });
        }
    }
}
