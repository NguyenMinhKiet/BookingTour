using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITourEmployeeRepository
    {
        // Phương thức lấy theo ID
        Task<TourEmployee> GetByIdAsync(Guid tour_id, Guid employee_id);

        // Phương thức lấy tất cả
        Task<IEnumerable<TourEmployee>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(TourEmployee tour);

        // Phương thức cập nhật
        Task UpdateAsync(TourEmployee tour);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid tour_id, Guid employee_id);
    }
}
