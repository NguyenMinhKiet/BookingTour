using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITourEmployeeRepository
    {
        // Phương thức lấy theo ID
        Task<TourEmployee> GetByIdAsync(int tour_id, int employee_id);

        // Phương thức lấy tất cả
        Task<IEnumerable<TourEmployee>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(TourEmployee tour);

        // Phương thức cập nhật
        Task UpdateAsync(TourEmployee tour);

        // Phương thức xóa theo ID
        Task DeleteAsync(int tour_id, int employee_id);
    }
}
