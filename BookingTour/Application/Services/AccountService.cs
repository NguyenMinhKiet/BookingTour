using Application.DTOs.AccountDTOs;
using Application.DTOs.BookingDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _Repository;
        public AccountService(IAccountRepository repository)
        {
            _Repository = repository;
        }
        public async Task<Account> CreateAsync(AccountCreateDto dto)
        {

            var acc = new Account()
            {
                Id = new Guid(),
                Username = dto.Username,
                Password = dto.Password,
                Email = dto.Email,
                Phone = dto.Phone,
                isActive = true
            };
            await _Repository.AddAsync(acc);
            return acc;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _Repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Account> GetById(Guid id)
        {
            return await _Repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Guid id, AccountUpdateDto dto)
        {
            var acc = await _Repository.GetByIdAsync(id);
            if (acc == null)
            {
                throw new Exception($"Không tìm thấy Account: {id} !!");
            }
            acc.Username = dto.Username;
            acc.Password = dto.Password;
            acc.Email = dto.Email;
            acc.Phone = dto.Phone;
            acc.isActive = dto.isActive;

            await _Repository.UpdateAsync(acc);
        }

        public async Task<Account> GetByEmailAsync(string email)
        {
            return await _Repository.GetByEmailAsync(email);
        }

        public async Task<Account> GetByPhoneAsync(string phone)
        {
            return await _Repository.GetByPhoneAsync(phone);
        }
    }
}
