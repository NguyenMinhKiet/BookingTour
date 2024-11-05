using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class FeedbackViewModel
    {
        public int feedback_id { get; set; }
        public int customer_id { get; set; }
        public int tour_id { get; set; }
        public int rating { get; set; }
        public string comments { get; set; }

        public string full_name { get; set; }

    }
}
