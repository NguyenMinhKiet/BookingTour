namespace Application.DTOs.BookingDTOs
{
    public class BookingCreationDto
    {
        public Guid TourID { get; set; }
        public Guid CustomerID { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
    }
}
