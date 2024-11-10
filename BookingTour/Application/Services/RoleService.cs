using Application.DTOs.RoleDTOs;
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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _Repository;
        public RoleService(IRoleRepository repository)
        {
            _Repository = repository;
        }
        public async Task<Role> CreateAsync(RoleCreateDto dto)
        {

            var acc = new Role()
            {
                Id = new Guid(),
                Name = dto.Name,
                Code = dto.Code,
            };
            await _Repository.AddAsync(acc);
            return acc;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _Repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Role> GetById(Guid id)
        {
            return await _Repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Guid id, RoleUpdateDto dto)
        {
            var acc = await _Repository.GetByIdAsync(id);
            if (acc == null)
            {
                throw new Exception($"Không tìm thấy Role: {id} !!");
            }
            acc.Name = dto.Name;
            acc.Code = dto.Code;
            await _Repository.UpdateAsync(acc);
        }
    }
}
