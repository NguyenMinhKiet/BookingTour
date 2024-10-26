using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Repositories
{
    public interface IDestinationRepository
    {
        // Phương thức lấy theo ID
        Task<Destination> GetByIdAsync(int id);

        // Phương thức lấy tất cả
        Task<IEnumerable<Destination>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Destination destination);

        // Phương thức cập nhật
        Task UpdateAsync(Destination destination);

        // Phương thức xóa theo ID
        Task DeleteAsync(int id);
    }
}
