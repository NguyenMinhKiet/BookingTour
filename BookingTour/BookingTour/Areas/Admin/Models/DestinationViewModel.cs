using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
{
    public class DestinationViewModel
    {
        public Guid DestinationID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên địa điểm!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng mô tả!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn quốc gia!")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại địa điểm!")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn thành phố!")]
        public string SelectedCity { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn quận/huyện!")]
        public string SelectedDistrict { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phường/xã!")]
        public string SelectedWard { get; set; }

        public List<SelectListItem> Cities { get; set; } = new();
        public List<SelectListItem> Districts { get; set; } = new();
        public List<SelectListItem> Wards { get; set; } = new();

    }
}
