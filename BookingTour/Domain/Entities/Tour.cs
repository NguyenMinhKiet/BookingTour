using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Tour
    {
        [Key]
        public int tour_id { get; set; }
        [Required]
        public string tour_name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public DateTime start_Date { get; set; }
        [Required]
        public DateTime end_Date { get; set; }
        [Required]
        public int availableSeats { get; set; }

        public virtual ICollection<TourDestination> TourDestinations { get; set; }

        public virtual ICollection<TourEmployee> TourEmployees { get; set; }

        public virtual ICollection<Feedback> FeedBacks { get; set; }
    }
}
