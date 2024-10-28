using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich.Models
{
    public class Booking
    {
        [Key]
        private int Booking_id { get; set; }
        [Required]
        private int tour_id { get; set; }
        [Required]
        private int customer_id { get; set; }
        [Required]
        private DateTime booking_date { get; set; }
        [Required]
        private int num_people { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        private decimal total_price { get; set; }

    }
}
