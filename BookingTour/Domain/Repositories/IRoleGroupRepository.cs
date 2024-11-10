using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRoleGroupRepository
    {
        // Phương thức lấy theo ID
        Task<RoleGroup> GetByIdAsync(Guid RoleID);

        // Phương thức lấy tất cả
        Task<IEnumerable<RoleGroup>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(RoleGroup role);

        // Phương thức cập nhật
        Task UpdateAsync(RoleGroup role);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid RoleID);
    }
}
