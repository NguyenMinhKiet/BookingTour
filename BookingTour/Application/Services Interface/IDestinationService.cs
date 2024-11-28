using Application.DTOs.DestinationDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface IDestinationService
    {
        public Task<Destination> GetById(Guid id);

        public Task<IEnumerable<Destination>> GetAllAsync();

        public Task CreateAsync(DestinationCreationDto dto);

        public Task UpdateAsync(DestinationUpdateDto dto);

        public Task DeleteAsync(Guid id);

        public Task<IEnumerable<Destination>> GetByCategoryAsync(string Category);
        public Task<IEnumerable<Destination>> GetByCityAsync(string city);
    }
}
