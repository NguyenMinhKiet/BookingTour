namespace Presentation.Models
{
    public class BookingViewModel
    {
        public int booking_id { get; set; }
        public int tour_id { get; set; }
        public int customer_id { get; set; }
        public DateTime booking_date { get; set; }
        public int num_people { get; set; }
        public decimal total_price { get; set; }
    }
}
