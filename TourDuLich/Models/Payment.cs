using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class Payment
    {
        [Key]
        private int payment_id { get; set; }
        [Required]
        private int booking_id { get; set; }
        [Required]
        private DateTime payment_date { get; set; }
        [Required]
        [StringLength(50)]
        private string payment_method { get; set; }
    }
}
