using Application.DTOs.HotelDto;
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
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task CreateAsync(HotelModel dto)
        {
            var HotelModel = new Hotel
            {
                HotelID = Guid.NewGuid(),
                Name = dto.Name.Trim(),
                StarRating = dto.StarRating,
                Description = dto.Description,
                City = dto.SelectedCity,
                District = dto.SelectedDistrict,
                Ward = dto.SelectedWard,
                Address = dto.Address.Trim(),
                Image = dto.Image ?? "Hotel_default.jpg"
            };
            await _hotelRepository.AddAsync(HotelModel);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _hotelRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync(string? City)
        {
            return await _hotelRepository.GetAllAsync(City);
        }

        public async Task<Hotel> GetByIdAsync(Guid HotelID)
        {
            return await _hotelRepository.GetByIdAsync(HotelID);
        }

        public async Task UpdateAsync(HotelModel dto)
        {
            var HotelModel = new Hotel
            {
                HotelID = dto.HotelID,
                Name = dto.Name.Trim(),
                StarRating = dto.StarRating,
                Description = dto.Description,
                City = dto.SelectedCity,
                District = dto.SelectedDistrict,
                Ward = dto.SelectedWard,
                Address = dto.Address.Trim(),
                Image = dto.Image ?? "Hotel_default.jpg"
            };
            await _hotelRepository.UpdateAsync(HotelModel);
        }
    }
}
