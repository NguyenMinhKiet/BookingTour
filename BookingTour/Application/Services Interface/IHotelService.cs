using Application.DTOs.FeedbackDTOs;
using Application.DTOs.HotelDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services_Interface
{
    public interface IHotelService
    {
        public Task<IEnumerable<Hotel>> GetAllAsync(string? City);
        public Task<Hotel> GetByIdAsync(Guid HotelID);
        public Task CreateAsync(HotelDto dto);

        public Task UpdateAsync(HotelDto dto);

        public Task DeleteAsync(Guid id);
    }
}
