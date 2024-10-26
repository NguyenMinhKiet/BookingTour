using TourDuLich.Domain.Entities;
using TourDuLich.Domain.Services;

namespace TourDuLich.Application.Services
{
    public class TourDestinationService : ITourDestinationService
    {
        public Task AddDestinationToTourAsync(int tourId, int destinationId, DateTime visitDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TourDestination>> GetTourDestinationsAsync(int tourId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveDestinationFromTourAsync(int tourDestinationId)
        {
            throw new NotImplementedException();
        }
    }
}
