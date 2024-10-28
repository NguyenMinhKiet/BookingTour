namespace TourDuLich.Domain.Entities
{
    public class Booking
    {
        private int Booking_id { get; set; }
        private int tour_id { get; set; }
        private int customer_id { get; set; }
        private DateTime booking_date { get; set; }
        private int num_people { get; set; }
        private decimal total_price { get; set; }

    }
}
