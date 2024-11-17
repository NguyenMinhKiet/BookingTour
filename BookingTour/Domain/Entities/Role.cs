using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
        public Role(string roleName, string description)
        : base(roleName)
        {
            Description = description;
        }

        public Role() { }
    }
}
