using Application.DTOs.BookingDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{

    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ITourService _TourService;
        public BookingService(IBookingRepository bookingRepository, ITourService tourService)
        {
            _bookingRepository = bookingRepository;
            _TourService = tourService;
        }

        

        public async Task<bool> CreateAsync(BookingCreationDto dto)
        {
            var price = (await _TourService.GetByIdAsync(dto.TourID)).Price;
            var childPrice = price * 50 / 100;
            var booking = new Booking()
            {
                BookingID = Guid.NewGuid(),
                TourID = dto.TourID,
                CustomerID = dto.CustomerID,
                CreateAt = DateTime.Now,
                Adult = dto.Adult,
                Child = dto.Child,
                TotalPrice = price * dto.Adult + childPrice * dto.Child
            };
            var numpeople = dto.Adult + dto.Child;
            var tour = await _TourService.GetByIdAsync(dto.TourID);
            if (tour != null)
            {
                    var result = await _TourService.ReducePeople(dto.TourID, numpeople);
                    if (result)
                    {
                        await _bookingRepository.AddAsync(booking);
                        return true;
                    }
            }
            return false;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _bookingRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<Booking> GetById(Guid id)
        {
            return await _bookingRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Guid booking_id, BookingUpdateDto dto)
        {
            var booking = await _bookingRepository.GetByIdAsync(booking_id);
            if (booking == null)
            {
                return false;
            }
            var price = (await _TourService.GetByIdAsync(booking.TourID)).Price;
            var childPrice = price * 50 / 100;

            var numPeopleOld = booking.Adult + booking.Child;

            booking.ModifyAt = DateTime.Now;
            booking.Adult = dto.Adult;
            booking.Child = dto.Child;
            booking.TotalPrice = price * dto.Adult + childPrice * dto.Child;


            await _bookingRepository.UpdateAsync(booking);

            var numPeopleNew = dto.Adult + dto.Child;

            await _TourService.IncreasePeople(booking.TourID,numPeopleOld);
            var reduce = await _TourService.ReducePeople(booking.TourID, numPeopleNew);
            if (!reduce)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CancelBooking(Guid id)
        {
            var booking = await GetById(id);
            if (booking != null)
            {
                var numPeople = booking.Adult + booking.Child;

                await _TourService.IncreasePeople(booking.TourID, numPeople);
                await DeleteAsync(id);
                return true;
            }
            return false;
        }
    }
}
