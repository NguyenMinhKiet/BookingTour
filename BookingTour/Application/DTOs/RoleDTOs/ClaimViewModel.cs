using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.RoleDTOs
{
    public class ClaimViewModel
    {
        public Guid? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool Selected { get; set; }
    }
}
