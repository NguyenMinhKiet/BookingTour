using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role : IdentityRole
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual RoleGroup RoleGroup { get; set; }
        public virtual ICollection<Authorized> AuthorizedAccounts { get; set; }
    }
}
