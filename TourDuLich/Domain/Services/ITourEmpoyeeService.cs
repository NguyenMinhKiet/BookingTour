using TourDuLich.Application.DTOs.TourEmployeeDTOs;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Services
{
    public interface ITourEmpoyeeService
    {
        Task<IEnumerable<TourEmployee>> GetAllTourEmployeesAsync();
        Task<TourEmployee> GetTourEmployeesByIdAsync(int tourId);
        Task<TourEmployee> CreateTourEmployeesAsync(TourEmployeeCreationDto tourDto);
        Task UpdateTourEmployeesAsync(int tourId, TourEmployeeUpdateDto tourDto);
        Task DeleteTourEmployeesAsync(int tourId);
    }
}
