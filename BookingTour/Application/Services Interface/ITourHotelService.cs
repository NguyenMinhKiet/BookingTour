using Application.DTOs.TourHotelDto;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface ITourHotelService
    {
        public Task<IEnumerable<TourHotel>> GetAllAsync();
        public Task<IEnumerable<TourHotel>> GetByTourID(Guid TourID);
        public Task<TourHotel> GetById(Guid TourID, Guid HotelID);

        public Task CreateAsync(TourHotelCreationDto hotel);
        public Task DeleteAsync(Guid TourID, Guid HotelID);
    }
}
