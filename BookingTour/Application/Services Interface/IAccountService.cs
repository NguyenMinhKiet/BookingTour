
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
        public Task<Account> GetById(Guid id);

        public Task<Account> CreateAsync(AccountCreateDto dto);

        public Task UpdateAsync(Guid BookingID, AccountUpdateDto dto);

        public Task DeleteAsync(Guid id);
        public Task<Account> GetByEmailAsync(string email);
        public Task<Account> GetByPhoneAsync(string phone);

    }
}
