﻿using Application.DTOs.CustomerDTOs;
using Application.DTOs.FeedbackDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services_Interface
{
    public interface IFeedbackService
    {
        public Task<Feedback> GetById(int id);

        public Task<IEnumerable<Feedback>> GetAllAsync();

        public Task<Feedback> CreateAsync(FeedbackCreationDto dto);

        public Task UpdateAsync(int id, FeedbackUpdateDto dto);

        public Task DeleteAsync(int id);
    }
}