using Application.DTOs.AuthorizedDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services_Interface
{
    public interface IAuthorizedService
    {
        public Task<Authorized> GetById(Guid id);

        public Task<Authorized> CreateAsync(AuthorizedCreateDto dto);

        public Task UpdateAsync(Guid booking_id, AuthorizedUpdateDto dto);

        public Task DeleteAsync(Guid id);
    }
}
