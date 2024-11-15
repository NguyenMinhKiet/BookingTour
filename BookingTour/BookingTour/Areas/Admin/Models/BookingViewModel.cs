using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
{
    public class BookingViewModel
    {
        public Guid BookingID { get; set; }
        public Guid TourID { get; set; }
        public Guid CustomerID { get; set; }
        [Required(ErrorMessage = "Nhập số lượng người lớn !")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng người lớn phải lớn hơn 0.")]
        public int Adult { get; set; }

        [Required(ErrorMessage = "Nhập số lượng trẻ em !")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng trẻ em không thể âm.")]
        public int Child { get; set; }

        [Required(ErrorMessage = "Nhập giá tiền > 0")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá tiền phải lớn hơn 0.")]
        public decimal TotalPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
    }
}
