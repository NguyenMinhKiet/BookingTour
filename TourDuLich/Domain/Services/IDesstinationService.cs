using TourDuLich.Application.DTOs.DestinationDTOs;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Services
{
    public interface IDesstinationService
    {
        Task<IEnumerable<Destination>> GetAllDestinationsAsync();
        Task<Destination> GetDestinationByIdAsync(int destinationId);
        Task<Destination> CreateDestinationAsync(DestinationCreationDto destinationDto);
        Task UpdateDestinationAsync(int destinationId, DestinationUpdateDto destinationDto);
        Task DeleteDestinationAsync(int destinationId);
    }
}
