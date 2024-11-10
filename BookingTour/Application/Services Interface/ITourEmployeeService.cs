using Application.DTOs.TourDestinationDTOs;
using Application.DTOs.TourEmployeeDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services_Interface
{
    public interface ITourEmployeeService
    {
        public Task<TourEmployee> GetById(Guid tour_id, Guid employee_id);

        public Task<IEnumerable<TourEmployee>> GetAllAsync();

        public Task<TourEmployee> CreateAsync(TourEmployeeCreationDto dto);

        public Task DeleteAsync(Guid tour_id, Guid employee_id);
    }
}
