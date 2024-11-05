using Application.DTOs.TourDTOs;
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
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        public TourService(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<Tour> CreateAsync(TourCreationDto dto)
        {
            var tour = new Tour()
            {
                tour_name = dto.tour_name,
                description = dto.description,
                price = dto.price,
                end_Date = dto.end_Date,
                start_Date = dto.start_Date,
                availableSeats = dto.availableSeats,
            };
            await _tourRepository.AddAsync(tour);
            return tour;
        }

        public async Task DeleteAsync(int id)
        {
            await _tourRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Tour>> GetAllAsync()
        {
            return await _tourRepository.GetAllAsync();
        }

        public async Task<Tour> GetById(int id)
        {
            return await _tourRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, TourUpdateDto dto)
        {
            var tour = await _tourRepository.GetByIdAsync(id);
            if(tour != null)
            {
                tour.tour_name = dto.tour_name;
                tour.description = dto.description;
                tour.price = dto.price;
                tour.start_Date = dto.start_Date;
                tour.end_Date = dto.end_Date;
                tour.description = dto.description;
                tour.availableSeats = dto.availableSeats;

                await _tourRepository.UpdateAsync(tour);

            }
        }
    }
}
