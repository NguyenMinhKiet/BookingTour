using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAuthorizedRepository
    {
        // Phương thức lấy theo ID
        Task<Authorized> GetByIdAsync(Guid id);

        // Phương thức lấy tất cả
        Task<IEnumerable<Authorized>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Authorized booking);

        // Phương thức cập nhật
        Task UpdateAsync(Authorized booking);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid id);
    }
}
