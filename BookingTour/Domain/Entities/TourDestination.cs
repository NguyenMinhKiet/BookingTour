
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TourDestination
    {
        
        public int tour_id { get; set; }
        public int destination_id { get; set; }
        public DateTime visit_date { get; set; }



        public virtual Tour Tour { get; set; }

        public virtual Destination Destination { get; set; }
    }
}
