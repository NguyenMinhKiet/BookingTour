using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
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
    }
}
