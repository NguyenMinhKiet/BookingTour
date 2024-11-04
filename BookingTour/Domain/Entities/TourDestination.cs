using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TourDestination
    {
        [Key]
        public int tourDestination_id { get; set; }
        [Required]
        public int tour_id { get; set; }
        [Required]
        public int destination_id { get; set; }
        [Required]
        public DateTime visit_date { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual Destination Destination { get; set; }
    }
}
