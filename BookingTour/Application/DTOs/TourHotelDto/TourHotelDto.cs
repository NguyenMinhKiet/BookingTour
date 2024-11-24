
using Domain.Entities;

namespace Application.DTOs.TourHotelDto
{
    public class TourHotelDto
    {
        public Guid TourID { get; set; }
        public virtual Tour Tour { get; set; }
        public Guid HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
