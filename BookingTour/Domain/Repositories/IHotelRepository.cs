using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IHotelRepository
    {
        // Phương thức lấy theo ID
        Task<Hotel> GetByIdAsync(Guid Hotel);

        // Phương thức lấy tất cả
        Task<IEnumerable<Hotel>> GetAllAsync(string? City);

        // Phương thức thêm
        Task AddAsync(Hotel Hotel);

        // Phương thức cập nhật
        Task UpdateAsync(Hotel Hotel);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid id);
    }
}
