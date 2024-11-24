
namespace Application.DTOs.HotelDto
{
    public class HotelWithDateDto
    {
        public HotelModel hotel { get; set; }
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
    }
}
