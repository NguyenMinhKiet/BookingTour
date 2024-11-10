using Application.DTOs.BookingDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
        private readonly ITourRepository _tourRepository;
        public BookingService(IBookingRepository bookingRepository, ITourRepository tourRepository)
        {
            _bookingRepository = bookingRepository;
            _tourRepository = tourRepository;
        }
        public async Task<Booking> CreateAsync(BookingCreationDto dto)
        {
            var price = (await _tourRepository.GetByIdAsync(dto.TourID)).Price;
            var childPrice = price * 50 / 100;
            var booking = new Booking()
            {
                BookingID = new Guid(),
                TourID = dto.TourID,
                CustomerID = dto.CustomerID,
                CreateAt = new DateTime(),
                Adult = dto.Adult,
                Child = dto.Child,
                TotalPrice = price * dto.Adult + childPrice * dto.Child
            };
            await _bookingRepository.AddAsync(booking);
            return booking;
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

        public async Task UpdateAsync(Guid booking_id, BookingUpdateDto dto)
        {
            var booking = await _bookingRepository.GetByIdAsync(booking_id);
            if (booking == null)
            {
                throw new Exception($"Không tìm thấy booking: {booking_id} !!");
            }
            var price = (await _tourRepository.GetByIdAsync(booking.TourID)).Price;
            var childPrice = price * 50 / 100;

            booking.ModifyAt = new DateTime();
            booking.Adult = dto.Adult;
            booking.Child = dto.Child;
            booking.TotalPrice = price * dto.Adult + childPrice * dto.Child;

            await _bookingRepository.UpdateAsync(booking);
        }
    }
}
