﻿namespace TourDuLich.Domain.Entities
{
    public class TourDestination
    {
        public int tourDestination_id { get; set; }
        public int tour_id { get; set; }
        public int destination_id { get; set; }
        public DateTime visit_date { get; set; }
    }
}