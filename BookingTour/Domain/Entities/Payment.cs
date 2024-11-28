
namespace Domain.Entities
{
    public class Payment
    {
        public Guid PaymentID { get; set; }
        public Guid BookingID { get; set; }
        public Guid CustomerID { get; set; }    
        public string Method { get; set; }
        public bool Status { get; set; }
        public decimal Total { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
