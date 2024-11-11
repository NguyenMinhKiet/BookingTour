using Application.DTOs.CustomerDTOs;
using Application.DTOs.DestinationDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface IDestinationService
    {
        public Task<Destination> GetById(Guid id);

        public Task<IEnumerable<Destination>> GetAllAsync();

        public Task<Destination> CreateAsync(DestinationCreationDto dto);

        public Task UpdateAsync(Guid id, DestinationUpdateDto dto);

        public Task DeleteAsync(Guid id);

        public Task<IEnumerable<Destination>> GetByCategoryAsync(string Category);
    }
}
