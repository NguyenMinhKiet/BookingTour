using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class Feedback
    {
        [Key]
        private int feedback_id { get; set; }
        [Required]
        private int customer_id { get; set; }
        [Required]
        private int tour_id { get; set; }
        [Required]
        private int rating { get; set; }
        private string comments { get; set; }
    }
}
