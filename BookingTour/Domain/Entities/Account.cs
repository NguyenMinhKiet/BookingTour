using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account : IdentityUser
    {
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }

        //public virtual RoleGroup RoleGroup { get; set; }
        //public virtual ICollection<Authorized> AuthorizedRoles { get; set; }

    }
}
