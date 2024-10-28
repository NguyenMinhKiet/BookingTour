namespace TourDuLich.Application.DTOs.BookingDTOs
{
    public class BookingUpdateDto
    {
        public DateTime BookingDate { get; set; }
        public int NumPeople { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
