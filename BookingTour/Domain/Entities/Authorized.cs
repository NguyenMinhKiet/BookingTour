using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Authorized
    {
        public Guid Id { get; set; }
        public Guid AccountID { get; set; }
        public Guid GroupID { get; set; }

        public virtual Account Account { get; set; }
        public virtual RoleGroup RoleGroup { get; set; }
    }
}
