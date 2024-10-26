using TourDuLich.Application.DTOs.FeedbackDTOs;
using TourDuLich.Domain.Entities;

namespace TourDuLich.Domain.Services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetFeedbacksByTourIdAsync(int tourId);
        Task<Feedback> CreateFeedbackAsync(FeedbackCreationDto feedbackDto);
        Task UpdateFeedbackAsync(int feedbackId, FeedbackUpdateDto feedbackDto);
        Task DeleteFeedbackAsync(int feedbackId);
    }
}
