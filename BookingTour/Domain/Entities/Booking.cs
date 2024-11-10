using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Booking
    {

        public Guid BookingID { get; set; }
        public Guid TourID { get; set; }
        public Guid CustomerID { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }

        // Thuộc tính điều hướng đến Customer
        public virtual Customer Customer { get; set; }
        public virtual Tour Tour { get; set; }


        public virtual Payment Payment { get; set; }
        


    }
}
