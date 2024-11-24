using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.TourHotelDto
{
    public class TourHotelCreationDto
    {
        public Guid TourID { get; set; }
        public Guid HotelID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
