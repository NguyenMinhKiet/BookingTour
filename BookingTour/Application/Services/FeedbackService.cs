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
                customer_id = dto.customer_id,
                tour_id = dto.tour_id,
                rating = dto.rating,
                comments = dto.comments,
            };
            await _feedbackRepository.AddAsync(newFeedback);
            return newFeedback;
        }

        public async Task DeleteAsync(int id)
        {
            await _feedbackRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await  _feedbackRepository.GetAllAsync();
        }

        public async Task<Feedback> GetById(int id)
        {
            return await _feedbackRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, FeedbackUpdateDto dto)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id);
            if (feedback != null)
            {
                feedback.tour_id = dto.tour_id;
                feedback.rating = dto.rating;
                feedback.comments = dto.comments;
                await _feedbackRepository.UpdateAsync(feedback);
            }

        }
    }
}
