using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Tour
    {
        public int tour_id { get; set; }
        public string tour_name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public DateTime start_Date { get; set; }
        public DateTime end_Date { get; set; }
        public int availableSeats { get; set; }

        public virtual ICollection<TourDestination> TourDestinations { get; set; }

        public virtual ICollection<TourEmployee> TourEmployees { get; set; }

        public virtual ICollection<Feedback> FeedBacks { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
