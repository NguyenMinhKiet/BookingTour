using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.TourDTOs
{
    public class TourCustomerView
    {
        public Guid TourID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tựa đề Tour !")]
        [StringLength(100, ErrorMessage = "Tựa đề Tour không được vượt quá 100 ký tự.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả !")]
        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá tiền > 0 !")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá tiền phải lớn hơn 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày bắt đầu Tour !")]
        [DataType(DataType.Date, ErrorMessage = "Ngày bắt đầu không hợp lệ.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày kết thúc Tour !")]
        [DataType(DataType.Date, ErrorMessage = "Ngày kết thúc không hợp lệ.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số chỗ > 0 !")]
        [Range(1, int.MaxValue, ErrorMessage = "Số chỗ ngồi phải lớn hơn 0.")]
        public int AvailableSeats { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại Tour !")]
        public string City {  get; set; }
        public string Category { get; set; }

        // Kiểm tra nếu StartDate < EndDate
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate >= EndDate)
            {
                yield return new ValidationResult("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", new[] { "StartDate", "EndDate" });
            }
        }
    }
}
