using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.PaymentDTOs
{
    public class PaymentUpdateDto
    {
        public Guid PaymentID { get; set; }
        public Guid BookingID { get; set; }
        // Kiểm tra không để Method rỗng hoặc null
        [Required(ErrorMessage = "Phương thức thanh toán là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Phương thức thanh toán không được dài quá 50 ký tự.")]
        public string Method { get; set; }

        // Kiểm tra Total phải là số không âm
        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền phải là giá trị không âm.")]
        public decimal Total { get; set; }

        // Kiểm tra Status, mặc dù kiểu bool không cần phải kiểm tra gì thêm
        public bool Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifyAt { get; set; }
    }
}
