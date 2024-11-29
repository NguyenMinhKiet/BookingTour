using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEmployeeRepository
    {
        // Phương thức lấy theo ID
        Task<Employee> GetByIdAsync(Guid id);
        Task<Employee> GetByUserID(Guid UserID);

        // Phương thức lấy tất cả
        Task<IEnumerable<Employee>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Employee employee);

        // Phương thức cập nhật
        Task UpdateAsync(Employee employee);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid id);

        Task<String> GetNameByIdAsync(Guid id);
        Task<String> GetPositionByIdAsync(Guid id);
        Task<IEnumerable<Employee>> GetAllWithOutTour(Guid TourID);
    }
}
