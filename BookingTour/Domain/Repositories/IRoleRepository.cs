using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public  interface IRoleRepository
    {
        // Phương thức lấy theo ID
        Task<Role> GetByIdAsync(int RoleID);

        // Phương thức lấy tất cả
        Task<IEnumerable<Role>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Role role);

        // Phương thức cập nhật
        Task UpdateAsync(Role role);

        // Phương thức xóa theo ID
        Task DeleteAsync(int RoleID);
    }
}
