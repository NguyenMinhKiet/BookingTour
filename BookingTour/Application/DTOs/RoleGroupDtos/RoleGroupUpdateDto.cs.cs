using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.RoleGroupDtos
{
    public class RoleGroupUpdateDto
    {
        public string Name { get; set; }
        public Guid RoleID { get; set; }
    }
}
