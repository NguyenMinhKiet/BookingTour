using Application.DTOs.TourHotelDto;
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
    public class TourHotelService : ITourHotelService
    {
        private readonly ITourHotelRepository _tourHotelRepository;
        public TourHotelService(ITourHotelRepository tourHotelRepository)
        {
            _tourHotelRepository = tourHotelRepository;
        }

        public async Task CreateAsync(TourHotelDto hotel)
        {
            var tourHotel = new TourHotel
            {
                HotelID = hotel.HotelID,
                Tour = hotel.Tour,
                TourID = hotel.TourID,
                Hotel = hotel.Hotel,
                StartDate = hotel.StartDate,
                EndDate = hotel.EndDate,
            };
           await  _tourHotelRepository.CreateAsync(tourHotel);
        }

        public async Task DeleteAsync(Guid TourID, Guid HotelID)
        {
            await _tourHotelRepository.DeleteAsync(TourID, HotelID);
        }

        public async Task<IEnumerable<TourHotel>> GetAllAsync()
        {
            return await _tourHotelRepository.GetAllAsync();
        }

        public async Task<TourHotel> GetById(Guid TourID, Guid HotelID)
        {
            return await _tourHotelRepository.GetByIdAsync(TourID, HotelID);
        }

        public async Task<IEnumerable<TourHotel>> GetByTourID(Guid TourID)
        {
            return await _tourHotelRepository.GetByTourID(TourID);
        }
    }
}
