using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Booking
    {

        public int booking_id { get; set; }
        public int tour_id { get; set; }
        public int customer_id { get; set; }
        public DateTime booking_date { get; set; }
        public int num_people { get; set; }
        public decimal total_price { get; set; }

        // Thuộc tính điều hướng đến Customer
        public virtual Customer Customer { get; set; }
        public virtual Tour Tour { get; set; }


        public virtual ICollection<Payment> Payments { get; set; }
        


    }
}
