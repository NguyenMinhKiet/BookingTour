using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Payment
    {
        public Guid PaymentID { get; set; }
        public Guid BookingID { get; set; }
        public string Method { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
