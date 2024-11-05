using Application.DTOs.TourDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface ITourService
    {
        public Task<Tour> GetById(int id);

        public Task<IEnumerable<Tour>> GetAllAsync();

        public Task<Tour> CreateAsync(TourCreationDto dto);

        public Task UpdateAsync(int id, TourUpdateDto dto);

        public Task DeleteAsync(int id);
    }
}
