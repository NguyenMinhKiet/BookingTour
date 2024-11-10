using Application.DTOs.DestinationDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Country = dto.Country,
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
                destiantion.City = dto.City;
                destiantion.Country = dto.Country;

                await _destinationRepository.UpdateAsync(destiantion);
            }
        }
    }
}
