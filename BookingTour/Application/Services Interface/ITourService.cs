using Application.DTOs.TourDTOs;
using Domain.Entities;

namespace Application.Services_Interface
{
    public interface ITourService
    {
        public Task<Tour> GetByIdAsync(Guid id);

        public Task<IEnumerable<Tour>> GetAllAsync();
        public Task<IEnumerable<Tour>> GetToursByCategoriesAsync(List<string> categories);
        public Task<Tour> CreateAsync(TourCreationDto dto);

        public Task UpdateAsync(Guid id, TourUpdateDto dto);

        public Task DeleteAsync(Guid id);
        Task<bool> ReducePeople(Guid TourID, int numPeople);
        Task<bool> IncreasePeople(Guid TourID, int numPeople);

        Task<List<Feedback>> GetFeedbacks(Guid TourID);
        Task<List<TourHotel>> GetHotels(Guid TourID);
        Task<List<TourDestination>> GetDestinations (Guid TourID);
        Task<List<TourEmployee>> GetEmployees (Guid TourID);
        Task<List<Tour>> GetAllNewAsync(string search, decimal? from, decimal? to, string? sortBy, string? Category)    ;
        Task<List<Tour>> GetAllByName(string name);
        Task<List<Tour>> GetAllWithOut(Guid TourID);

    }
}
