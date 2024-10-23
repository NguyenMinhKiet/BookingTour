using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class Feedback
    {
        [Key]
        public int feedback_id { get; set; }
        [Required]
        public int customer_id {  get; set; }
        [Required]
        public int tour_id { get; set; }
        [Required]
        public int rating { get; set; }
        public string comments { get; set; }
    }
}
