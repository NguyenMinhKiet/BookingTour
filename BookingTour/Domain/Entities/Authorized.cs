using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Authorized
    {
        public Guid AccountID { get; set; }
        public Guid GroupID { get; set; }
        public Guid RoleID { get; set; }

        public virtual Role Roles { get; set; }
        public virtual RoleGroup RoleGroup { get; set; }
        public virtual Account Account { get; set; }
    }
}
