
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TourDestination
    {
        
        public Guid TourID { get; set; }
        public Guid DestinationID { get; set; }
        public DateTime VisitDate { get; set; }

        public virtual Tour Tour { get; set; }

        public virtual Destination Destination { get; set; }
    }
}
