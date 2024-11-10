using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.RoleDTOs
{
    public class RoleCreateDto
    {
        public Guid RoleID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
