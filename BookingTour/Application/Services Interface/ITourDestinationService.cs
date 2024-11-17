using Application.DTOs.TourDestinationDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface ITourDestinationService
    {
        public Task<TourDestination> GetById(Guid tour_id, Guid destination_id);

        public Task<IEnumerable<TourDestination>> GetAllAsync();

        public Task<TourDestination> CreateAsync(TourDestinationCreationDto dto);

        public Task UpdateAsync(Guid tour_id, Guid destination_id, TourDestinationUpdateDto dto);

        public Task DeleteAsync(Guid tour_id, Guid destination_id);
        public Task<IEnumerable<TourDestination>> GetByTourIdAsync(Guid TourID);

    }
}
