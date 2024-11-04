using Domain.Entities;

namespace Domain.Repositories
{
    public interface IFeedbackRepository
    {
        // Phương thức lấy theo ID
        Task<Feedback> GetByIdAsync(int id);

        // Phương thức lấy tất cả
        Task<IEnumerable<Feedback>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Feedback feedback);

        // Phương thức cập nhật
        Task UpdateAsync(Feedback feedback);

        // Phương thức xóa theo ID
        Task DeleteAsync(int id);
    }
}
