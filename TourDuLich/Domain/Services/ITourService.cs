using TourDuLich.Application.DTOs.TourDTOs;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Services
{
    public interface ITourService
    {
        Task<IEnumerable<Tour>> GetAllToursAsync();
        Task<Tour> GetTourByIdAsync(int tourId);
        Task<Tour> CreateTourAsync(TourCreationDto tourDto);
        Task UpdateTourAsync(int tourId, TourUpdateDto tourDto);
        Task DeleteTourAsync(int tourId);
    }
}
