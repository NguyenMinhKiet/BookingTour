using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Services
{
    public interface ITourDestinationService
    {
        Task<IEnumerable<TourDestination>> GetTourDestinationsAsync(int tourId);
        Task AddDestinationToTourAsync(int tourId, int destinationId, DateTime visitDate);
        Task RemoveDestinationFromTourAsync(int tourDestinationId);
    }
}
