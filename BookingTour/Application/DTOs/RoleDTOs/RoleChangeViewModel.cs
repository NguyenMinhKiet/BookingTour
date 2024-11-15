using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.DTOs.RoleDTOs
{
    public class RoleChangeViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string CurrentRole { get; set; }
        public List<SelectListItem> Roles { get; set; } // Danh sách các roles
    }

}
