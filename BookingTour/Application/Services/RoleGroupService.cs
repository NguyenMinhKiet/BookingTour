using Application.DTOs.RoleDTOs;
using Application.DTOs.RoleGroupDtos;
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
    public class RoleGroupService : IRoleGroupService
    {
        private readonly IRoleGroupRepository _Repository;
        public RoleGroupService(IRoleGroupRepository repository)
        {
            _Repository = repository;
        }
        public async Task<RoleGroup> CreateAsync(RoleGroupCreateDto dto)
        {

            var acc = new RoleGroup()
            {
                Id = new Guid(),
                Name = dto.Name,
                RoleID = dto.RoleID,
            };
            await _Repository.AddAsync(acc);
            return acc;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _Repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RoleGroup>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<RoleGroup> GetById(Guid id)
        {
            return await _Repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Guid id, RoleGroupUpdateDto dto)
        {
            var acc = await _Repository.GetByIdAsync(id);
            if (acc == null)
            {
                throw new Exception($"Không tìm thấy RoleGroup: {id} !!");
            }
            acc.Name = dto.Name;
            acc.RoleID = dto.RoleID;
            await _Repository.UpdateAsync(acc);
        }
    }
}
