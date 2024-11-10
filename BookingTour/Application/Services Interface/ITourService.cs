using Application.DTOs.TourDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface ITourService
    {
        public Task<Tour> GetById(Guid id);

        public Task<IEnumerable<Tour>> GetAllAsync();

        public Task<Tour> CreateAsync(TourCreationDto dto);

        public Task UpdateAsync(Guid id, TourUpdateDto dto);

        public Task DeleteAsync(Guid id);
    }
}
