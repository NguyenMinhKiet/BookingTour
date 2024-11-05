using Domain.Entities;

namespace Presentation.Models
{
    public class PaymentViewModel
    {
        /*
            payment_status:
                0: Đã thanh toán
                1: Chưa thanh toán
         */

        public int payment_id { get; set; }
        public int booking_id { get; set; }
        public DateTime payment_date { get; set; }
        public string payment_method { get; set; } 
        public int payment_status { get; set; }



    }
}
