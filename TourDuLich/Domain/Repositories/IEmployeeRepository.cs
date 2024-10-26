using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        // Phương thức lấy theo ID
        Task<Employee> GetByIdAsync(int id);

        // Phương thức lấy tất cả
        Task<IEnumerable<Employee>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Employee employee);

        // Phương thức cập nhật
        Task UpdateAsync(Employee employee);

        // Phương thức xóa theo ID
        Task DeleteAsync(int id);
    }
}
