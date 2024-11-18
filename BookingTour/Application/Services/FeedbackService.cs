using Application.DTOs.FeedbackDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }


        public async Task<Feedback> CreateAsync(FeedbackCreationDto dto)
        {
            var newFeedback = new Feedback()
            {
                FeedbackID = Guid.NewGuid(),
                CustomerID = dto.CustomerID,
                TourID = dto.TourID,
                Rating = dto.Rating,
                Comments = dto.Comments.Trim(),
                CreateAt = DateTime.Now
            };
            await _feedbackRepository.AddAsync(newFeedback);
            return newFeedback;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _feedbackRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await  _feedbackRepository.GetAllAsync();
        }

        public async Task<Feedback> GetById(Guid id)
        {
            return await _feedbackRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Feedback>> GetByTourID(Guid TourID)
        {
            return await _feedbackRepository.GetByTourID(TourID);
        }

        public async Task UpdateAsync(Guid id, FeedbackUpdateDto dto)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback != null)
            {
                feedback.ModifyAt = DateTime.Now;
                feedback.Rating = dto.Rating;
                feedback.Comments = dto.Comments.Trim();
                await _feedbackRepository.UpdateAsync(feedback);
            }

        }
    }
}
