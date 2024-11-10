using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITourDestinationRepository
    {
        // Phương thức lấy theo ID
        Task<TourDestination> GetByIdAsync(Guid tour_id, Guid destination_id);

        // Phương thức lấy tất cả
        Task<IEnumerable<TourDestination>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(TourDestination tourDestination);

        // Phương thức cập nhật
        Task UpdateAsync(TourDestination tourDestination);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid tour_id, Guid destination_id);
    }
}
