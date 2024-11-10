using Domain.Entities;
namespace Domain.Repositories
{
    public interface IRoleGroupRepository
    {
        // Phương thức lấy theo ID
        Task<RoleGroup> GetByIdAsync(Guid id);

        // Phương thức lấy tất cả
        Task<IEnumerable<RoleGroup>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(RoleGroup booking);

        // Phương thức cập nhật
        Task UpdateAsync(RoleGroup booking);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid id);
    }
}
