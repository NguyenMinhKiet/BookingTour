using Application.DTOs.TourDestinationDTOs;
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
    public class TourDestinationService : ITourDestinationService
    {
        private readonly ITourDestinationRepository _tourDestinationRepository;

        public TourDestinationService(ITourDestinationRepository tourDestinationRepository)
        {
            _tourDestinationRepository = tourDestinationRepository;
        }


        public async Task<TourDestination> CreateAsync(TourDestinationCreationDto dto)
        {
            var tourDestination = new TourDestination()
            {
                TourID = dto.TourID,
                DestinationID = dto.DestinationID,
                VisitDate = dto.VisitDate
            };
            await _tourDestinationRepository.AddAsync(tourDestination);
            return tourDestination;
        }

        

        public async Task<IEnumerable<TourDestination>> GetAllAsync()
        {
            return await _tourDestinationRepository.GetAllAsync();
        }

        public async Task<TourDestination> GetById(Guid tour_id, Guid destination_id)
        {
            return await _tourDestinationRepository.GetByIdAsync(tour_id, destination_id);
        }

        public async Task UpdateAsync(Guid tour_id, Guid destination_id, TourDestinationUpdateDto dto)
        {
            var tourDestination = await _tourDestinationRepository.GetByIdAsync(tour_id, destination_id);
            if( tourDestination != null)
            {
                tourDestination.VisitDate = dto.VisitDate;
                await _tourDestinationRepository.UpdateAsync(tourDestination);
            }
        }

        public async Task DeleteAsync(Guid tour_id, Guid destination_id)
        {
            await _tourDestinationRepository.DeleteAsync(tour_id, destination_id);
        }
    }
}
