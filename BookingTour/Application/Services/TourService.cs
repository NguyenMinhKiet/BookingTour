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
using System.Web.WebPages;

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
                TourID = Guid.NewGuid(),  // Đã sửa để dùng Guid.NewGuid() thay vì new Guid()
                Title = dto.Title.Trim(),
                Description = dto.Description.Trim(),
                Price = dto.Price,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                AvailableSeats = dto.AvailableSeats,
                Category = dto.Category.Trim().Normalize(),
                // Chuẩn hóa tên thành phố
                City = dto.City.Trim().Normalize()  // Loại bỏ dấu trong tên thành phố
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
                tour.Title = dto.Title.Trim();
                tour.Description = dto.Description.Trim();
                tour.Price = dto.Price;
                tour.StartDate = dto.StartDate;
                tour.EndDate = dto.EndDate;
                tour.AvailableSeats = dto.AvailableSeats;
                tour.Category = dto.Category.Trim().Normalize();
                tour.City = dto.City.Trim().Normalize();

                await _tourRepository.UpdateAsync(tour);

            }
        }

        public async Task<bool> ReducePeople(Guid TourID, int numPeople)
        {
            var tour = await _tourRepository.GetByIdAsync(TourID);
            if(tour != null)
            {
                if(tour.AvailableSeats < numPeople)
                {
                    return false;
                }
                tour.AvailableSeats = tour.AvailableSeats - numPeople;
                return true;
            }
            return false;
        }

        public async Task<bool> IncreasePeople(Guid TourID, int numPeople)
        {
            var tour = await _tourRepository.GetByIdAsync(TourID);
            if (tour != null)
            {
                tour.AvailableSeats = tour.AvailableSeats + numPeople;
                return true;
            }
            return false;
        }

        public async Task<List<TourDestination>> GetDestinations(Guid TourID)
        {
            return await _tourRepository.GetDestinations(TourID);
        }

        public async Task<List<TourEmployee>> GetEmployees(Guid TourID)
        {
            return await _tourRepository.GetEmployees(TourID);
        }
    }
}
