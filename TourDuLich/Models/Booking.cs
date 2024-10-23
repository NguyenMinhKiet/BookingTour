using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich.Models
{
    public class Booking
    {
        [Key]
        public int Booking_id { get; set; }
        [Required]
        public int tour_id { get; set; }
        [Required]
        public int customer_id { get; set; }
        [Required]
        public DateTime booking_date { get; set; }
        [Required]
        public int num_people { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal total_price { get; set; }

    }
}
