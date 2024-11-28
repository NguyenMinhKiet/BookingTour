using Domain.Entities;

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
