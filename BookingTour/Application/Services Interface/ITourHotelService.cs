using Application.DTOs.TourHotelDto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services_Interface
{
    public interface ITourHotelService
    {
        public Task<IEnumerable<TourHotel>> GetAllAsync();
        public Task<IEnumerable<TourHotel>> GetByTourID(Guid TourID);
        public Task<TourHotel> GetById(Guid TourID, Guid HotelID);

        public Task CreateAsync(TourHotelDto hotel);
        public Task DeleteAsync(Guid TourID, Guid HotelID);
    }
}
