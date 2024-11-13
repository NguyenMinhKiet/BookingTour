using System.ComponentModel.DataAnnotations;

namespace Areas.Admin.Models
{
    public class DestinationViewModel
    {
        public Guid DestinationID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên địa điểm !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng mô tả !")]
        public string Description { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn loại địa điểm !")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thành phố !")]
        public string City { get; set; }
    }
}
