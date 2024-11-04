using Application.DTOs.CustomerDTOs;
using Application.DTOs.DestinationDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface IDestinationService
    {
        public Task<Destination> GetById(int id);

        public Task<IEnumerable<Destination>> GetAllAsync();

        public Task<Destination> CreateAsync(DestinationCreationDto dto);

        public Task UpdateAsync(int id, DestinationUpdateDto dto);

        public Task DeleteAsync(int id);
    }
}
