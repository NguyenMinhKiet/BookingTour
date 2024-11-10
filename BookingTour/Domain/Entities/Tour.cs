using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Tour
    {
        public Guid TourID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AvailableSeats { get; set; }

        public virtual ICollection<TourDestination> TourDestinations { get; set; }

        public virtual ICollection<TourEmployee> TourEmployees { get; set; }

        public virtual ICollection<Feedback> FeedBacks { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
