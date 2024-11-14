using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
{
    public class TourViewModel
    {
        public Guid TourID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tựa đề Tour !")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả !")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá tiền > 0 !")]
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số chỗ > 0 !")]
        public int AvailableSeats { get; set; }
        [Required(ErrorMessage = "Vui lòng loại Tour !")]
        public string Category { get; set; }
    }
}
