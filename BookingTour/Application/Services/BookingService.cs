using Application.DTOs.BookingDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
            var tourPrice = (await _tourRepository.GetByIdAsync(dto.tour_id)).price;
            var booking = new Booking()
            {
                tour_id = dto.tour_id,
                customer_id = dto.customer_id,
                booking_date = dto.booking_date,
                num_people = dto.num_people,
                total_price = tourPrice * dto.num_people,
            };
            await _bookingRepository.AddAsync(booking);
            return booking;
        }

        public async Task DeleteAsync(int id)
        {
            await _bookingRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<Booking> GetById(int id)
        {
            return await _bookingRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int booking_id, BookingUpdateDto dto)
        {
            var booking = await _bookingRepository.GetByIdAsync(booking_id);
            if (booking == null)
            {
                throw new Exception($"Không tìm thấy booking: {booking_id} !!");
            }
            var tourPrice = (await _tourRepository.GetByIdAsync(dto.tour_id)).price;

            booking.customer_id = dto.customer_id;
            booking.booking_date = dto.booking_date;
            booking.total_price = tourPrice * dto.num_people;
            booking.tour_id = dto.tour_id;
            booking.num_people = dto.num_people;

            await _bookingRepository.UpdateAsync(booking);
        }
    }
}
