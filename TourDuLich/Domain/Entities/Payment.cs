namespace TourDuLich.Domain.Entities
{
    public class Payment
    {
        private int payment_id { get; set; }
        private int booking_id { get; set; }
        private DateTime payment_date { get; set; }
        private string payment_method { get; set; }
    }
}
