using Domain.Entities;

namespace Presentation.Models
{
    public class TourDestinationViewModel
    {
        public Guid TourID { get; set; }
        public Guid DestinationID { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
