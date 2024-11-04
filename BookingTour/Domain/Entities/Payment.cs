using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
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
        public string payment_method { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
