namespace TourDuLich.Application.DTOs.TourDTOs
{
    public class TourCreationDto
    {
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Constructor nếu cần
        public TourCreationDto(int tourId, string tourName, string description, decimal price, DateTime startDate, DateTime endDate)
        {
            TourId = tourId;
            TourName = tourName;
            Description = description;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
