namespace Application.DTOs.TourDTOs
{
    public class TourCreationDto
    {
        public string TourName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AvailableSeats { get; set; }
    }
}
