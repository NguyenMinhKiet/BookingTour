using Application.DTOs.RoleDTOs;
using Application.DTOs.RoleGroupDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services_Interface
{
    public interface IRoleGroupService
    {
        public Task<RoleGroup> GetById(Guid id);

        public Task<IEnumerable<RoleGroup>> GetAllAsync();

        public Task<RoleGroup> CreateAsync(RoleGroupCreateDto dto);

        public Task UpdateAsync(Guid id, RoleGroupUpdateDto dto);

        public Task DeleteAsync(Guid id);
    }
}
