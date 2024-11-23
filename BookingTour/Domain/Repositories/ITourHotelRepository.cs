using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITourHotelRepository
    {
        Task<TourHotel> GetByIdAsync(Guid TourID, Guid HotelID);
        // Phương thức lấy tất cả
        Task<IEnumerable<TourHotel>> GetAllAsync();
        Task<IEnumerable<TourHotel>> GetByTourID(Guid TourID);
        // Phương thức thêm
        Task AddAsync(TourHotel TourHotel);

        // Phương thức cập nhật
        Task UpdateAsync(TourHotel TourHotel);

        // Phương thức xóa theo ID
        Task DeleteAsync(Guid TourID, Guid HotelID);
    }
}
