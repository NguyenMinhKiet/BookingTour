using Domain.Entities;
namespace Domain.Repositories
{
    public interface ITourRepository
    {
        // Phương thức lấy theo ID
        Task<Tour> GetByIdAsync(Guid id);

        // Phương thức lấy tất cả
        Task<IEnumerable<Tour>> GetAllAsync();

        // Phương thức thêm
        Task AddAsync(Tour tour);

        // Phương thức cập nhật
        Task UpdateAsync(Tour tour);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid id);

        Task<List<TourDestination>> GetDestinations(Guid TourID);
        Task<List<TourEmployee>> GetEmployees(Guid TourID);

        Task<IEnumerable<Tour>> GetToursByCategories(List<string> categories);


        Task<List<Tour>> GetAll(string search, decimal? from, decimal? to, string? orderBy);
        Task<List<Tour>> GetAllByName(string name);
        Task<List<Tour>> GetAllWithOut(string category);

    }
}
