using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.RoleDTOs
{
    public class RoleClaimsViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<ClaimViewModel> Claims { get; set; }
    }
}
