using Application.DTOs.DestinationDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using System.Globalization;
using System.Text;
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
                DestinationID = Guid.NewGuid(),
                Name = dto.Name.Trim(),
                City = NormalizeCity(dto.City.Trim()),
                Description = dto.Description.Trim(),
                Country = NormalizeCity(dto.Country.Trim()),
                Category = NormalizeCity(dto.Category.Trim()),
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
                destiantion.Category = NormalizeCity(dto.Category.Trim());
                destiantion.City = NormalizeCity(dto.City.Trim());

                await _destinationRepository.UpdateAsync(destiantion);
            }
        }

        public static string NormalizeCity(string city)
        {
            return city.Normalize(NormalizationForm.FormD)
                       .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                       .Aggregate("", (current, c) => current + c);
        }


    }
}
