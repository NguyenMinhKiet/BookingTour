using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int feedback_id { get; set; }
        public int customer_id { get; set; }
        public int tour_id { get; set; }
        public int rating { get; set; }
        public string comments { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
