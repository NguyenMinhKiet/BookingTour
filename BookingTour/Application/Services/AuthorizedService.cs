using Application.DTOs.AuthorizedDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthorizedService : IAuthorizedService
    {
        private readonly IAuthorizedRepository _Repository;
        public AuthorizedService(IAuthorizedRepository repository)
        {
            _Repository = repository;
        }
        public async Task<Authorized> CreateAsync(AuthorizedCreateDto dto)
        {

            var acc = new Authorized()
            {
                Id = new Guid(),
                AccountID = dto.AccountID,
                GroupID = dto.GroupID,
            };
            await _Repository.AddAsync(acc);
            return acc;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _Repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Authorized>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Authorized> GetById(Guid id)
        {
            return await _Repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Guid id, AuthorizedUpdateDto dto)
        {
            var acc = await _Repository.GetByIdAsync(id);
            if (acc == null)
            {
                throw new Exception($"Không tìm thấy Authorized: {id} !!");
            }
            acc.AccountID = dto.AccountID;
            acc.GroupID = dto.GroupID;

            await _Repository.UpdateAsync(acc);
        }
    }
}
