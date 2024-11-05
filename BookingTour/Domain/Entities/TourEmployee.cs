using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TourEmployee
    {
        public int tour_id { get; set; }
        public int employee_id { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
