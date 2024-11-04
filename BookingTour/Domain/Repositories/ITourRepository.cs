using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITourRepository
    {
        // Phương thức lấy theo ID
        Task<Tour> GetByIdAsync(int id);

        // Phương thức lấy tất cả
        Task<IEnumerable<Tour>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Tour tour);

        // Phương thức cập nhật
        Task UpdateAsync(Tour tour);

        // Phương thức xóa theo ID
        Task DeleteAsync(int id);
    }
}
