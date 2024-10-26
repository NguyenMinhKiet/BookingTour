using TourDuLich.Application.DTOs.FeedbackDTOs;
using TourDuLich.Domain.Entities;
using TourDuLich.Domain.Services;

namespace TourDuLich.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        public Task<Feedback> CreateFeedbackAsync(FeedbackCreationDto feedbackDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFeedbackAsync(int feedbackId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Feedback>> GetFeedbacksByTourIdAsync(int tourId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFeedbackAsync(int feedbackId, FeedbackUpdateDto feedbackDto)
        {
            throw new NotImplementedException();
        }
    }
}
