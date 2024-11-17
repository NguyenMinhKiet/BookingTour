using Application.DTOs.TourDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface ITourService
    {
        public Task<Tour> GetByIdAsync(Guid id);

        public Task<IEnumerable<Tour>> GetAllAsync();

        public Task<Tour> CreateAsync(TourCreationDto dto);

        public Task UpdateAsync(Guid id, TourUpdateDto dto);

        public Task DeleteAsync(Guid id);
        Task<bool> ReducePeople(Guid TourID, int numPeople);
        Task<bool> IncreasePeople(Guid TourID, int numPeople);

    }
}
