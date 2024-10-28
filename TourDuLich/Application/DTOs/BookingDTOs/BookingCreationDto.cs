namespace TourDuLich.Application.DTOs.BookingDTOs
{
    public class BookingCreationDto
    {
        public int TourId { get; set; }
        public int CustomerId { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumPeople { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
