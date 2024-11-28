
namespace Presentation.Areas.Admin.Models
{
    public class PaymentViewModel
    {
        /*
            Status
                1: Đã thanh toán
                0: Chưa thanh toán
         */

        public Guid PaymentID { get; set; }
        public Guid BookingID { get; set; }
        public string Method { get; set; }
        public bool Status { get; set; }
        public decimal Total { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }



    }
}
