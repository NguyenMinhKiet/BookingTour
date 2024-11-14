using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AccountDTOs
{
    public class AccountCreationResult
    {
        public IdentityResult Result { get; set; }
        public string UserId { get; set; }
    }
}
