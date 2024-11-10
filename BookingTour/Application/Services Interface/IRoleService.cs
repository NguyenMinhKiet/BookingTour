using Application.DTOs.RoleDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services_Interface
{
    public interface IRoleService
    {
        public Task<Role> GetById(Guid id);

        public Task<IEnumerable<Role>> GetAllAsync();

        public Task<Role> CreateAsync(RoleCreateDto dto);

        public Task UpdateAsync(Guid id, RoleUpdateDto dto);

        public Task DeleteAsync(Guid id);
    }
}
