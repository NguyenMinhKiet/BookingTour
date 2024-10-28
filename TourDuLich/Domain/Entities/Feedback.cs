using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Domain.Entities
{
    public class Feedback
    {
        private int feedback_id { get; set; }
        private int customer_id { get; set; }
        private int tour_id { get; set; }
        private int rating { get; set; }
        private string comments { get; set; }
    }
}
