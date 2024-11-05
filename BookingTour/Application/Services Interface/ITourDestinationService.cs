using Application.DTOs.TourDestinationDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface ITourDestinationService
    {
        public Task<TourDestination> GetById(int tour_id, int destination_id);

        public Task<IEnumerable<TourDestination>> GetAllAsync();

        public Task<TourDestination> CreateAsync(TourDestinationCreationDto dto);

        public Task UpdateAsync(int tour_id, int destination_id, TourDestinationUpdateDto dto);

        public Task DeleteAsync(int tour_id, int destination_id);
    }
}
