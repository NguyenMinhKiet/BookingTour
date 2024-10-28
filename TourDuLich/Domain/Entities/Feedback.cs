using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Domain.Entities
{
    public class Feedback
    {
        public int feedback_id { get; set; }
        public int customer_id { get; set; }
        public int tour_id { get; set; }
        public int rating { get; set; }
        public string comments { get; set; }
    }
}
