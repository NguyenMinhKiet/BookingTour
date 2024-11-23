using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
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

        public string Address { get; set; }
        public string SelectedCity { get; set; }
        public string SelectedDistrict { get; set; }
        public string SelectedWard { get; set; }
        public List<SelectListItem> Cities { get; set; } = new();
        public List<SelectListItem> Districts { get; set; } = new();
        public List<SelectListItem> Wards { get; set; } = new();

    }
}
