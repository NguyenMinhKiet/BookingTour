using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPaymentRepository
    {
        // Phương thức lấy theo ID
        Task<Payment> GetByIdAsync(int id);

        // Phương thức lấy tất cả
        Task<IEnumerable<Payment>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Payment payment);

        // Phương thức cập nhật
        Task UpdateAsync(Payment payment);

        // Phương thức xóa theo ID
        Task DeleteAsync(int id);
    }
}
