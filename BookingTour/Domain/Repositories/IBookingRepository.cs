using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBookingRepository
    {
        // Phương thức lấy theo ID
        Task<Booking> GetByIdAsync(Guid id);

        // Phương thức lấy tất cả
        Task<IEnumerable<Booking>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Booking booking);

        // Phương thức cập nhật
        Task UpdateAsync(Booking booking);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid id);
    }
}
