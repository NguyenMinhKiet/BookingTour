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
            // Chuyển đổi DTO thành Entity
            var tour = new Tour
            {
                tour_name = tourDto.TourName,
                description = tourDto.Description,
                price = tourDto.Price,
                start_Date = tourDto.StartDate,
                end_Date = tourDto.EndDate,
                availableSeats = tourDto.AvailableSeats
            };

            // Thêm tour vào cơ sở dữ liệu
            await _tourRepository.AddAsync(tour);

            // Chuyển đổi Entity thành DTO để trả về
            var createdTourDto = new Tour
            {
                tour_name = tour.tour_name,
                description = tour.description,
                price = tour.price,
                start_Date = tour.start_Date,
                end_Date = tour.end_Date,
                availableSeats = tour.availableSeats
            };

            return createdTourDto; // Trả về DTO của tour vừa tạo
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
