using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Permission
    {
        public string Value { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public Permission(string value, string description, bool isActive)
        {
            Value = value;
            Description = description;
            IsActive = isActive;
        }
        public Permission() { } 
    }
}
