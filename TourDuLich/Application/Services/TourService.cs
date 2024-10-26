using TourDuLich.Application.DTOs.TourDTOs;
using TourDuLich.Domain.Entities;
using TourDuLich.Domain.Repositories;
using TourDuLich.Domain.Services;

namespace TourDuLich.Application.Services
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;

        public TourService(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<Tour> CreateTourAsync(TourCreationDto tourDto)
        {
            var tour = new Tour
            {
                tour_name = tourDto.TourName,
                description = tourDto.Description,
                price = tourDto.Price,
                startDate = tourDto.StartDate,
                endDate = tourDto.EndDate,
                AvailableSeats = tourDto.AvailableSeats
            };

            await _tourRepository.AddAsync(tour);
            return new TourCreationDto { }
        }

        public Task DeleteTourAsync(int tourId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tour>> GetAllToursAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tour> GetTourByIdAsync(int tourId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTourAsync(int tourId, TourUpdateDto tourDto)
        {
            throw new NotImplementedException();
        }
    }
}
