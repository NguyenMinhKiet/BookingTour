using Domain.Entities;

namespace Presentation.Models
{
    public class TourDestinationViewModel
    {
        public int tour_id { get; set; }
        public int destination_id { get; set; }
        public DateTime visit_date { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
