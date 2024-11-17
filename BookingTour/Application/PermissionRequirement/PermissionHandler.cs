using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PermissionRequirement
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {


            var permissions = context.User.Claims
                            .Where(c => c.Type == "permission")
                            .Select(c => c.Value)
                            .ToList();

            if (permissions != null)
            {
                foreach(var claim in permissions)
                {
                    // Giải mã JSON từ Claim
                    var permissionData = JsonConvert.DeserializeObject<Permission>(claim);
                    Console.WriteLine($"Permission: {permissionData.Value} == {requirement.RequiredPermission}  ");
                    if (permissionData?.Value == requirement.RequiredPermission && permissionData.IsActive)
                    {
                        Console.WriteLine("===> Finded");
                        context.Succeed(requirement);
                        break;
                    }
                }
                
            }

            return Task.CompletedTask;
        }
    }
}
