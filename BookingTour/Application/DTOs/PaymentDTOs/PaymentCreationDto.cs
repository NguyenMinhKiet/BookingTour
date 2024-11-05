namespace Application.DTOs.PaymentDTOs
{
    public class PaymentCreationDto
    {
        public int booking_id { get; set; }
        public DateTime payment_date { get; set; } = DateTime.Now;
        public string payment_method { get; set; }
        public int payment_status { get; set; }
    }
}
