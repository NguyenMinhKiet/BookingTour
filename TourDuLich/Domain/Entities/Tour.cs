﻿namespace TourDuLich.Domain.Entities
{
    public class Tour
    {
        public int tour_id { get; set; }
        public string tour_name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public DateTime start_Date { get; set; }
        public DateTime end_Date { get; set; }
    }
}