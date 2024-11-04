using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TourEmployee
    {
        
        [Key]
        public int tour_id { get; set; }
        [Key]
        public int employee_id { get; set; }
        [Required]
        public string position { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
