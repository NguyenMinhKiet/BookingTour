using Application.DTOs.DestinationDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Entities.Location;
using Domain.Repositories;
using System.Globalization;
using System.Net;
using System.Text;
namespace Application.Services
{

    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;

        public DestinationService(IDestinationRepository destinationRepository) {
            _destinationRepository = destinationRepository;
        }


        public async Task CreateAsync(DestinationDto dto)
        {
            var destination = new Destination
            {
                DestinationID = Guid.NewGuid(),
                Name = dto.Name.Trim(),
                Description = dto.Description.Trim(),
                Country = dto.Country,
                Category = dto.Category,
                City = dto.City,
                District = dto.District,
                Ward = dto.Ward,
                Address = dto.Address.Trim(),
            };
            await _destinationRepository.AddAsync(destination);
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

        public async Task UpdateAsync(DestinationDto dto)
        {
            var destiantion = await _destinationRepository.GetByIdAsync(dto.DestinationID);
            if (destiantion != null)
            {
                destiantion.Name = dto.Name.Trim();
                destiantion.Country = dto.Country;
                destiantion.Description = dto.Description.Trim();
                destiantion.Category = dto.Category;
                destiantion.City = dto.City;
                destiantion.District = dto.District;
                destiantion.Ward = dto.Ward;
                destiantion.Address = dto.Address.Trim();

                await _destinationRepository.UpdateAsync(destiantion);
            }
        }

    }
}
