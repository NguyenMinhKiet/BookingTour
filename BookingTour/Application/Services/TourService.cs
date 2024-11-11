using Application.DTOs.TourDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                TourID = new Guid(),
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                AvailableSeats = dto.AvailableSeats,
                Category = dto.Category
            };
            await _tourRepository.AddAsync(tour);
            return tour;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _tourRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Tour>> GetAllAsync()
        {
            return await _tourRepository.GetAllAsync();
        }

        public async Task<Tour> GetByIdAsync(Guid id)
        {
            return await _tourRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Guid id, TourUpdateDto dto)
        {
            var tour = await _tourRepository.GetByIdAsync(id);
            if(tour != null)
            {
                tour.Title = dto.Title;
                tour.Description = dto.Description;
                tour.Price = dto.Price;
                tour.StartDate = dto.StartDate;
                tour.EndDate = dto.EndDate;
                tour.AvailableSeats = dto.AvailableSeats;
                tour.Category = dto.Category;

                await _tourRepository.UpdateAsync(tour);

            }
        }
    }
}
