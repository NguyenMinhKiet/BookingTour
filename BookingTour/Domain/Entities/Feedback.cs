using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Feedback
    {
        public Guid FeedbackID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid TourID { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
