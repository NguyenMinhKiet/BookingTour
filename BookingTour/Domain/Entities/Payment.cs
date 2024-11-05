using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Payment
    {
        public int payment_id { get; set; }
        public int booking_id { get; set; }
        public DateTime payment_date { get; set; }
        public string payment_method { get; set; }
        public int payment_status { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
