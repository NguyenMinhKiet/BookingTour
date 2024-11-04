using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class FeedbackViewModel
    {
        public int feedback_id;
        public int customer_id;
        public int tour_id;
        public int rating;
        public string comments;
    }
}
