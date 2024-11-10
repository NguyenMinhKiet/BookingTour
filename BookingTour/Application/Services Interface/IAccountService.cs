
using Application.DTOs.AccountDTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services_Interface
{
    public interface IAccountService
    {
        public Task<IdentityResult> Register(Account registerModel);
        public Task<IdentityResult> Login(Account loginModel)

    }
}
