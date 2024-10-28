using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Repositories
{
    public interface ITourEmployeeRepository
    {
        // Phương thức lấy theo ID
        Task<TourEmployee> GetByIdAsync(int id);

        // Phương thức lấy tất cả
        Task<IEnumerable<TourEmployee>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(TourEmployee tour);

        // Phương thức cập nhật
        Task UpdateAsync(TourEmployee tour);

        // Phương thức xóa theo ID
        Task DeleteAsync(int id);
    }
}
