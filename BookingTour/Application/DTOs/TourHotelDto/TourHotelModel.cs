
using Application.DTOs.HotelDto;
using Domain.Entities;

namespace Application.DTOs.TourHotelDto
{
    public class TourHotelModel
    {
        public Guid TourID { get; set; }
        public Tour Tour { get; set; }
        public List<HotelWithDateDto> Hotels { get; set; }
    }
}
