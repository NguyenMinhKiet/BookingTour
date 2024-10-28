namespace TourDuLich.Domain.Entities
{
    public class Payment
    {
        public int payment_id { get; set; }
        public int booking_id { get; set; }
        public DateTime payment_date { get; set; }
        public string payment_method { get; set; }
    }
}
