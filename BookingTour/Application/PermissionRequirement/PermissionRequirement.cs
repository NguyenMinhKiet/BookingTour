using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PermissionRequirement
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string RequiredPermission { get; }

        public PermissionRequirement(string requiredPermission)
        {
            RequiredPermission = requiredPermission;
        }
    }
}
