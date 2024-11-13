using Application.DTOs.DestinationDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{

    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;

        public DestinationService(IDestinationRepository destinationRepository) {
            _destinationRepository = destinationRepository;
        }


        public async Task<Destination> CreateAsync(DestinationCreationDto dto)
        {
            var destination = new Destination
            {
                DestinationID = new Guid(),
                Name = dto.Name,
                City = dto.City,
                Description = dto.Description,
                Country = "Việt Nam",
                Category = dto.Category,
            };
            await _destinationRepository.AddAsync(destination);
            return destination;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _destinationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _destinationRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Destination>> GetByCategoryAsync(string Category)
        {
            return await _destinationRepository.GetByCategoryAsync(Category);
        }

        public async Task<Destination> GetById(Guid id)
        {
            return await _destinationRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Guid id, DestinationUpdateDto dto)
        {
            var destiantion = await _destinationRepository.GetByIdAsync(id);
            if (destiantion != null)
            {
                destiantion.Name = dto.Name;
                destiantion.Country = dto.Country;
                destiantion.Description = dto.Description;
                destiantion.Category = dto.Category;
                destiantion.City = dto.City;

                await _destinationRepository.UpdateAsync(destiantion);
            }
        }

        
    }
}
