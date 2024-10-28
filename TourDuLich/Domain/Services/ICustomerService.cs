using TourDuLich.Application.DTOs.CustomerDTOs;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Services
{
    public interface ICustomerService
    {
        // Đăng ký khách hàng mới
        Task<Customer> RegisterCustomerAsync(CustomerCreationDto customerDetails);

        // Cập nhật thông tin khách hàng
        Task UpdateCustomerAsync(int customerId, CustomerUpdateDto updatedDetails);

        // Lấy thông tin khách hàng theo ID
        Task<Customer> GetCustomerByIdAsync(int customerId);

        // Lấy lịch sử đặt tour của khách hàng
        Task<IEnumerable<Booking>> GetCustomerBookingHistoryAsync(int customerId);

        // Xóa tài khoản khách hàng
        Task DeleteCustomerAsync(int customerId);
    }
}
