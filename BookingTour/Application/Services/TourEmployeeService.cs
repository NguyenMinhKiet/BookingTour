using Application.DTOs.TourEmployeeDTOs;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TourEmployeeService : ITourEmployeeService
    {
        private readonly ITourEmployeeRepository _tourEmployeeRepository;
        public TourEmployeeService (ITourEmployeeRepository tourEmployeeRepository)
        {
            _tourEmployeeRepository = tourEmployeeRepository;
        }


        public async Task<TourEmployee> CreateAsync(TourEmployeeCreationDto dto)
        {
            var tourEmployee = new TourEmployee()
            {
                TourID = dto.TourID,
                EmployeeID = dto.EmployeeID
            };
            await _tourEmployeeRepository.AddAsync(tourEmployee);
            return tourEmployee;
        }

        public async Task DeleteAsync(Guid tour_id, Guid employee_id)
        {
            await _tourEmployeeRepository.DeleteAsync(tour_id, employee_id);
        }

        public Task<IEnumerable<TourEmployee>> GetAllAsync()
        {
            return _tourEmployeeRepository.GetAllAsync();
        }

        public Task<TourEmployee> GetById(Guid tour_id, Guid employee_id)
        {
            return _tourEmployeeRepository.GetByIdAsync(tour_id, employee_id);
        }

    }
}
