using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Booking
    {

        [Key]
        public int booking_id { get; set; }
        [Required]
        public int tour_id { get; set; }
        [Required]
        public int customer_id { get; set; }
        [Required]
        public DateTime booking_date { get; set; }
        [Required]
        public int num_people { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Nhập số tiền >= 0 !!")]
        public decimal total_price { get; set; }

        // Thuộc tính điều hướng đến Customer
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }


    }
}
