using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRoleRepository
    {
        // Phương thức lấy theo ID
        Task<Account> GetByIdAsync(Guid id);

        // Phương thức lấy tất cả
        Task<IEnumerable<Account>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Account booking);

        // Phương thức cập nhật
        Task UpdateAsync(Account booking);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid id);
    }
}
