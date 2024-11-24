using Application.Attribute;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.TourDTOs
{
    public class TourCreationDto
    {
        [Required(ErrorMessage = "Tiêu đề là bắt buộc.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mô tả là bắt buộc.")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Ngày bắt đầu là bắt buộc.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc là bắt buộc.")]
        public DateTime EndDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng chỗ trống phải ít nhất là 1.")]
        public int AvailableSeats { get; set; }

        [Required(ErrorMessage = "Danh mục là bắt buộc.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Thành phố là bắt buộc.")]
        public string City { get; set; }


        [StartDateBeforeEndDate]
        public object? CustomValidation { get; set; }
    }
}
