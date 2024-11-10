using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RoleGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid RoleID { get; set; }
    }
}
