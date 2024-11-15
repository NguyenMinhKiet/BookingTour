using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.BookingDTOs
{
    public class BookingUpdateDto
    {
        public int Adult { get; set; }
        public int Child { get; set; }
    }
}
