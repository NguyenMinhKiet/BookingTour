using System.ComponentModel.DataAnnotations;

namespace Areas.Admin.Models
{
    public class BookingViewModel
    {
        public Guid BookingID { get; set; }
        public Guid TourID { get; set; }
        public Guid CustomerID { get; set; }
        [Required(ErrorMessage = "Nhập số lượng người lớn !")]
        public int Adult { get; set; }
        [Required(ErrorMessage = "Nhập số lượng trẻ em !")]
        public int Child { get; set; }
        [Required(ErrorMessage = "Nhập giá tiền > 0")]
        public decimal TotalPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
    }
}
