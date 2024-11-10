using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        // Phương thức lấy theo ID
        Task<Customer> GetByIdAsync(Guid id);

        // Phương thức lấy tất cả
        Task<IEnumerable<Customer>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Customer customer);

        // Phương thức cập nhật
        Task UpdateAsync(Customer customer);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid id);
    }
}
