using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
{
    public class FeedbackViewModel
    {
        public Guid FeedbackID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid TourID { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }

    }
}
