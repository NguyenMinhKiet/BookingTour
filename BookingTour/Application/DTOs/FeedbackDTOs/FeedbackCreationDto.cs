using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.FeedbackDTOs
{
    public class FeedbackCreationDto
    {
        public int customer_id;
        public int tour_id;
        public int rating;
        public string comments;
    }
}
