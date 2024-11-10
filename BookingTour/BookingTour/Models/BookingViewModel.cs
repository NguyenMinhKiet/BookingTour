namespace Presentation.Models
{
    public class BookingViewModel
    {
        public Guid BookingID { get; set; }
        public Guid TourID { get; set; }
        public Guid CustomerID { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
    }
}
