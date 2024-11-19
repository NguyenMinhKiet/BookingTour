using Application.DTOs.TourDTOs;

namespace Presentation.Models
{
    public class BookingConfirmModel
    {
        public TourViewModel TourData { get; set; }
        public CustomerViewModel CustomerData { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
    }
}
