using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.FeedbackDTOs
{
    public class FeedbackCreationDto
    {
        public Guid FeedbackID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid TourID { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}
