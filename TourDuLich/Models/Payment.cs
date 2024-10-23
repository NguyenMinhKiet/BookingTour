using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }
        [Required]
        public int booking_id { get; set; }
        [Required]
        public DateTime payment_date { get; set; }
        [Required]
        [StringLength(50)]
        public string payment_method { get; set; }
    }
}
