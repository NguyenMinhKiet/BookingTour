﻿namespace TourDuLich.Domain.Entities
{
    public class Booking
    {
        public int Booking_id { get; set; }
        public int tour_id { get; set; }
        public int customer_id { get; set; }
        public DateTime booking_date { get; set; }
        public int num_people { get; set; }
        public decimal total_price { get; set; }

    }
}