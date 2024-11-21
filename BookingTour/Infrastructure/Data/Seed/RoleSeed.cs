using Domain.Entities;
using Infrastructure.Static;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seed
{
    public class RoleSeed
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleSeed(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            // Get permissions from static class
            //var adminPermissions = PERMISSIONS.GetAllPermisstions();
            //var employeePermissions = PERMISSIONS.GetEmployeePermisstions();
            //var userPermissions = PERMISSIONS.GetCustomerPermisstions();

            var adminPermissions = new List<Permission>
            {
                // USER GROUP PERMISSIONS
                new Permission(PERMISSIONS.USER_GROUP_VIEW, "Xem danh sách nhóm người dùng", true),
                new Permission(PERMISSIONS.USER_GROUP_ADD, "Thêm nhóm người dùng mới", true),
                new Permission(PERMISSIONS.USER_GROUP_UPDATE, "Cập nhật thông tin nhóm người dùng", true),
                new Permission(PERMISSIONS.USER_GROUP_DELETE, "Xóa nhóm người dùng", true),

                // CUSTOMER PERMISSIONS
                new Permission(PERMISSIONS.CUSTOMER_VIEW, "Xem danh sách khách hàng", true),
                new Permission(PERMISSIONS.CUSTOMER_ADD, "Thêm khách hàng mới", true),
                new Permission(PERMISSIONS.CUSTOMER_UPDATE, "Cập nhật thông tin khách hàng", true),
                new Permission(PERMISSIONS.CUSTOMER_DELETE, "Xóa khách hàng", true),

                // EMPLOYEE PERMISSIONS
                new Permission(PERMISSIONS.EMPLOYEE_VIEW, "Xem danh sách nhân viên", true),
                new Permission(PERMISSIONS.EMPLOYEE_ADD, "Thêm nhân viên mới", true),
                new Permission(PERMISSIONS.EMPLOYEE_UPDATE, "Cập nhật thông tin nhân viên", true),
                new Permission(PERMISSIONS.EMPLOYEE_DELETE, "Xóa nhân viên", true),

                // DESTINATION PERMISSIONS
                new Permission(PERMISSIONS.DESTINATION_VIEW, "Xem danh sách điểm đến", true),
                new Permission(PERMISSIONS.DESTINATION_ADD, "Thêm điểm đến mới", true),
                new Permission(PERMISSIONS.DESTINATION_UPDATE, "Cập nhật thông tin điểm đến", true),
                new Permission(PERMISSIONS.DESTINATION_DELETE, "Xóa điểm đến", true),

                // TOUR PERMISSIONS
                new Permission(PERMISSIONS.TOUR_VIEW, "Xem danh sách tour", true),
                new Permission(PERMISSIONS.TOUR_ADD, "Thêm tour mới", true),
                new Permission(PERMISSIONS.TOUR_UPDATE, "Cập nhật thông tin tour", true),
                new Permission(PERMISSIONS.TOUR_DELETE, "Xóa tour", true),

                // TOUR DESTINATION PERMISSIONS
                new Permission(PERMISSIONS.TOUR_DESTINATION_VIEW, "Xem danh sách điểm đến trong tour", true),
                new Permission(PERMISSIONS.TOUR_DESTINATION_ADD, "Thêm điểm đến mới vào tour", true),
                new Permission(PERMISSIONS.TOUR_DESTINATION_UPDATE, "Cập nhật thông tin điểm đến trong tour", true),
                new Permission(PERMISSIONS.TOUR_DESTINATION_DELETE, "Xóa điểm đến trong tour", true),

                // TOUR EMPLOYEE PERMISSIONS
                new Permission(PERMISSIONS.TOUR_EMPLOYEE_VIEW, "Xem danh sách nhân viên trong tour", true),
                new Permission(PERMISSIONS.TOUR_EMPLOYEE_ADD, "Thêm nhân viên mới vào tour", true),
                new Permission(PERMISSIONS.TOUR_EMPLOYEE_UPDATE, "Cập nhật thông tin nhân viên trong tour", true),
                new Permission(PERMISSIONS.TOUR_EMPLOYEE_DELETE, "Xóa nhân viên khỏi tour", true),

                // BOOKING PERMISSIONS
                new Permission(PERMISSIONS.BOOKING_VIEW, "Xem danh sách đặt chỗ", true),
                new Permission(PERMISSIONS.BOOKING_ADD, "Thêm đặt chỗ mới", true),
                new Permission(PERMISSIONS.BOOKING_UPDATE, "Cập nhật thông tin đặt chỗ", true),
                new Permission(PERMISSIONS.BOOKING_DELETE, "Xóa đặt chỗ", true),

                // PAYMENT PERMISSIONS
                new Permission(PERMISSIONS.PAYMENT_VIEW, "Xem danh sách thanh toán", true),
                new Permission(PERMISSIONS.PAYMENT_ADD, "Thêm thanh toán mới", true),
                new Permission(PERMISSIONS.PAYMENT_UPDATE, "Cập nhật thông tin thanh toán", true),
                new Permission(PERMISSIONS.PAYMENT_DELETE, "Xóa thanh toán", true),

                // FEEDBACK PERMISSIONS
                new Permission(PERMISSIONS.FEEDBACK_VIEW, "Xem danh sách phản hồi", true),
                new Permission(PERMISSIONS.FEEDBACK_ADD, "Thêm phản hồi mới", true),
                new Permission(PERMISSIONS.FEEDBACK_UPDATE, "Cập nhật thông tin phản hồi", true),
                new Permission(PERMISSIONS.FEEDBACK_DELETE, "Xóa phản hồi", true),

                // ACCOUNT PERMISSIONS
                new Permission(PERMISSIONS.ACCOUNT_VIEW, "Xem danh sách tài khoản", true),
                new Permission(PERMISSIONS.ACCOUNT_ADD, "Thêm tài khoản mới", true),
                new Permission(PERMISSIONS.ACCOUNT_UPDATE, "Cập nhật thông tin tài khoản", true),
                new Permission(PERMISSIONS.ACCOUNT_DELETE, "Xóa tài khoản", true),

                // ROLE PERMISSIONS
                new Permission(PERMISSIONS.ROLE_VIEW, "Xem danh sách vai trò", true),
                new Permission(PERMISSIONS.ROLE_ADD, "Thêm vai trò mới", true),
                new Permission(PERMISSIONS.ROLE_UPDATE, "Cập nhật thông tin vai trò", true),
                new Permission(PERMISSIONS.ROLE_DELETE, "Xóa vai trò", true),

                // ROLE PERMISSIONS
                new Permission(PERMISSIONS.ROLE_Claim_VIEW, "Xem danh sách quyền vai trò", true),
                new Permission(PERMISSIONS.ROLE_Claim_ADD, "Thêm quyền mới", true),
                new Permission(PERMISSIONS.ROLE_Claim_UPDATE, "Cập nhật thông tin quyền", true),
                new Permission(PERMISSIONS.ROLE_Claim_DELETE, "Xóa quyền", true),
            };




            var userPermissions = new List<Permission>
            {
                // CUSTOMER PERMISSIONS
                new Permission(PERMISSIONS.CUSTOMER_VIEW, "Xem danh sách khách hàng", false),
                new Permission(PERMISSIONS.CUSTOMER_ADD, "Thêm khách hàng mới", true),
                new Permission(PERMISSIONS.CUSTOMER_UPDATE, "Cập nhật thông tin khách hàng", true),
                new Permission(PERMISSIONS.CUSTOMER_DELETE, "Xóa khách hàng", false),

                new Permission(PERMISSIONS.EMPLOYEE_VIEW, "Xem danh sách nhân viên", false),
                new Permission(PERMISSIONS.EMPLOYEE_ADD, "Thêm nhân viên mới", false),
                new Permission(PERMISSIONS.EMPLOYEE_UPDATE, "Cập nhật thông tin nhân viên", false),
                new Permission(PERMISSIONS.EMPLOYEE_DELETE, "Xóa nhân viên", false),

                // DESTINATION PERMISSIONS
                new Permission(PERMISSIONS.DESTINATION_VIEW, "Xem danh sách điểm đến", true),
                new Permission(PERMISSIONS.DESTINATION_ADD, "Thêm điểm đến mới", false),
                new Permission(PERMISSIONS.DESTINATION_UPDATE, "Cập nhật thông tin điểm đến", false),
                new Permission(PERMISSIONS.DESTINATION_DELETE, "Xóa điểm đến", false),

                // TOUR PERMISSIONS
                new Permission(PERMISSIONS.TOUR_VIEW, "Xem danh sách tour", true),
                new Permission(PERMISSIONS.TOUR_ADD, "Thêm tour mới", false),
                new Permission(PERMISSIONS.TOUR_UPDATE, "Cập nhật thông tin tour", false),
                new Permission(PERMISSIONS.TOUR_DELETE, "Xóa tour", false),

                // TOUR DESTINATION PERMISSIONS
                new Permission(PERMISSIONS.TOUR_DESTINATION_VIEW, "Xem danh sách điểm đến trong tour", true),
                new Permission(PERMISSIONS.TOUR_DESTINATION_ADD, "Thêm điểm đến mới vào tour", false),
                new Permission(PERMISSIONS.TOUR_DESTINATION_UPDATE, "Cập nhật thông tin điểm đến trong tour", false),
                new Permission(PERMISSIONS.TOUR_DESTINATION_DELETE, "Xóa điểm đến trong tour", false),

                // TOUR EMPLOYEE PERMISSIONS
                new Permission(PERMISSIONS.TOUR_EMPLOYEE_VIEW, "Xem danh sách nhân viên trong tour", true),
                new Permission(PERMISSIONS.TOUR_EMPLOYEE_ADD, "Thêm nhân viên mới vào tour", false),
                new Permission(PERMISSIONS.TOUR_EMPLOYEE_UPDATE, "Cập nhật thông tin nhân viên trong tour", false),
                new Permission(PERMISSIONS.TOUR_EMPLOYEE_DELETE, "Xóa nhân viên khỏi tour", false),

                // BOOKING PERMISSIONS
                new Permission(PERMISSIONS.BOOKING_VIEW, "Xem danh sách đặt chỗ", true),
                new Permission(PERMISSIONS.BOOKING_ADD, "Thêm đặt chỗ mới", true),
                new Permission(PERMISSIONS.BOOKING_UPDATE, "Cập nhật thông tin đặt chỗ", false),
                new Permission(PERMISSIONS.BOOKING_DELETE, "Xóa đặt chỗ", false),

                // PAYMENT PERMISSIONS
                new Permission(PERMISSIONS.PAYMENT_VIEW, "Xem danh sách thanh toán", false),
                new Permission(PERMISSIONS.PAYMENT_ADD, "Thêm thanh toán mới", true),
                new Permission(PERMISSIONS.PAYMENT_UPDATE, "Cập nhật thông tin thanh toán", false),
                new Permission(PERMISSIONS.PAYMENT_DELETE, "Xóa thanh toán", false),

                // FEEDBACK PERMISSIONS
                new Permission(PERMISSIONS.FEEDBACK_VIEW, "Xem danh sách phản hồi", true),
                new Permission(PERMISSIONS.FEEDBACK_ADD, "Thêm phản hồi mới", true),
                new Permission(PERMISSIONS.FEEDBACK_UPDATE, "Cập nhật thông tin phản hồi", true),
                new Permission(PERMISSIONS.FEEDBACK_DELETE, "Xóa phản hồi", true),

                // ACCOUNT PERMISSIONS
                new Permission(PERMISSIONS.ACCOUNT_VIEW, "Xem danh sách tài khoản", false),
                new Permission(PERMISSIONS.ACCOUNT_ADD, "Thêm tài khoản mới", true),
                new Permission(PERMISSIONS.ACCOUNT_UPDATE, "Cập nhật thông tin tài khoản", false),
                new Permission(PERMISSIONS.ACCOUNT_DELETE, "Xóa tài khoản", false),

                // ROLE PERMISSIONS
                new Permission(PERMISSIONS.ROLE_VIEW, "Xem danh sách vai trò", false),
                new Permission(PERMISSIONS.ROLE_ADD, "Thêm vai trò mới", false),
                new Permission(PERMISSIONS.ROLE_UPDATE, "Cập nhật thông tin vai trò", false),
                new Permission(PERMISSIONS.ROLE_DELETE, "Xóa vai trò", false),

                // ROLE PERMISSIONS
                new Permission(PERMISSIONS.ROLE_Claim_VIEW, "Xem danh sách quyền vai trò", false),
                new Permission(PERMISSIONS.ROLE_Claim_ADD, "Thêm quyền mới", false),
                new Permission(PERMISSIONS.ROLE_Claim_UPDATE, "Cập nhật thông tin quyền", false),
                new Permission(PERMISSIONS.ROLE_Claim_DELETE, "Xóa quyền", false),
            };



            await CreateRoleAsync("Admin", adminPermissions);
            await CreateRoleAsync("Manager", adminPermissions);
            await CreateRoleAsync("User", userPermissions);
        }

            private async Task CreateRoleAsync(string roleName, List<Permission> permissions)
            {
                // Check if the role already exists
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Create new role
                    var role = new Role(roleName, $"{roleName} Role");

                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        // Add claims (permissions)
                        foreach (var permission in permissions)
                        {
                            var claim = new System.Security.Claims.Claim("permission", JsonConvert.SerializeObject(permission));
                            await _roleManager.AddClaimAsync(role, claim);
                        }
                    }
                    else
                    {
                        // Handle failure to create role
                        Console.WriteLine($"Failed to create role {roleName}");
                    }
                }
            }
    }
}
