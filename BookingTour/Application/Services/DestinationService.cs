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
                destination_name = dto.destination_name,
                city = dto.city,
                country = dto.country,
            };
            await _destinationRepository.AddAsync(destination);
            return destination;
        }

        public async Task DeleteAsync(int id)
        {
            await _destinationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _destinationRepository.GetAllAsync();
        }

        public async Task<Destination> GetById(int id)
        {
            return await _destinationRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, DestinationUpdateDto dto)
        {
            var destiantion = await _destinationRepository.GetByIdAsync(id);
            if (destiantion != null)
            {
                destiantion.destination_name = dto.destination_name;
                destiantion.city = dto.city;
                destiantion.country = dto.country;

                await _destinationRepository.UpdateAsync(destiantion);
            }
        }
    }
}
