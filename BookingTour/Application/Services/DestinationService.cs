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
                Name = dto.Name.Trim(),
                City = dto.City.Trim().Normalize(),
                Description = dto.Description.Trim().Normalize(),
                Country = "Việt Nam",
                Category = dto.Category.Trim().Normalize(),
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

        public async Task<IEnumerable<Destination>> GetByCityAsync(string city)
        {
            return await _destinationRepository.GetByCityAsync(city);
        }

        public async Task<IEnumerable<Destination>> GetByCityAndCategoryAsync(string city, string category)
        {
            return await _destinationRepository.GetByCityAndCategoryAsync(city, category);
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
                destiantion.Name = dto.Name.Trim();
                destiantion.Country = dto.Country.Trim();
                destiantion.Description = dto.Description.Trim();
                destiantion.Category = dto.Category.Trim().Normalize();
                destiantion.City = dto.City.Trim().Normalize();

                await _destinationRepository.UpdateAsync(destiantion);
            }
        }

        
    }
}
