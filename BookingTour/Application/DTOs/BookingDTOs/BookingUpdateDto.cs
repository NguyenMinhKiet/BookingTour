using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.BookingDTOs
{
    public class BookingUpdateDto
    {
        public DateTime ModifyAt {  get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
