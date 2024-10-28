using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class TourDestination
    {
        [Key]
        private int tourDestination_id { get; set; }
        [Required]
        private int tour_id { get; set; }
        [Required]
        private int destination_id { get; set; }
        [Required]
        private DateTime visit_date { get; set; }
    }
}
