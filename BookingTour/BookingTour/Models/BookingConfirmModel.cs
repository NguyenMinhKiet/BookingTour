using Application.DTOs.TourDTOs;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class BookingConfirmModel
    {
        [Required(ErrorMessage = "Thông tin tour là bắt buộc.")]
        public TourViewModel TourData { get; set; }

        [Required(ErrorMessage = "Thông tin khách hàng là bắt buộc.")]
        public CustomerViewModel CustomerData { get; set; }

        [Required(ErrorMessage = "Số người lớn là bắt buộc.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số người lớn phải lớn hơn 0.")]
        public int Adult { get; set; }

        [Required(ErrorMessage = "Số trẻ em là bắt buộc.")]
        [Range(0, int.MaxValue, ErrorMessage = "Số trẻ em không thể âm.")]
        public int Child { get; set; }
    }
}
