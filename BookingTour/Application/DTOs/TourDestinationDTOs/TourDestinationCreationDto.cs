using Domain.Entities;

namespace Application.DTOs.TourDestinationDTOs
{
    public class TourDestinationCreationDto
    {
        public Guid TourID { get; set; }
        public Guid DestinationID { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
