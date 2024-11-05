using Domain.Entities;

namespace Application.DTOs.TourDestinationDTOs
{
    public class TourDestinationCreationDto
    {
        public int tour_id { get; set; }
        public int destination_id { get; set; }
        public DateTime visit_date { get; set; }
    }
}
