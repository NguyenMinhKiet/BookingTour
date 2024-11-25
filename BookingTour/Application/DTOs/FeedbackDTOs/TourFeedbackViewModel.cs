
namespace Application.DTOs.FeedbackDTOs
{
    public class TourFeedbackViewModel
    {
        public Guid TourID { get; set; }
        public Guid CustomerID { get; set; }
        public string TourName { get; set;}
        public List<FeedbackViewModel> Feedbacks { get; set; }
    }
}
