using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public interface IDestinationRepository
    {
        // Phương thức lấy theo ID
        Task<Destination> GetByIdAsync(Guid id);

        // Phương thức lấy tất cả
        Task<IEnumerable<Destination>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Destination destination);

        // Phương thức cập nhật
        Task UpdateAsync(Destination destination);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Destination>> GetByCategoryAsync(string Category);
        Task<IEnumerable<Destination>> GetByCityAsync(string City);

          Task<IEnumerable<Destination>> GetByCityAndCategoryAsync(string City, string Category);
         Task<IEnumerable<string>> GetCategory(string City);
    }
}
