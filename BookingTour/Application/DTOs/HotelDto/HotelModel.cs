using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.HotelDto
{
    public class HotelModel
    {
        public Guid HotelID { get; set; }
        [Required(ErrorMessage = "Tên địa điểm là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên địa điểm không được quá 100 ký tự.")]
        public string Name { get; set; }

        [Range(1, 5, ErrorMessage = "Đánh giá sao phải trong phạm vi từ 1 đến 5.")]
        public int StarRating { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được quá 500 ký tự.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
        [StringLength(200, ErrorMessage = "Địa chỉ không được quá 200 ký tự.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Thành phố là bắt buộc.")]
        public string SelectedCity { get; set; }

        [Required(ErrorMessage = "Quận/Huyện là bắt buộc.")]
        public string SelectedDistrict { get; set; }

        [Required(ErrorMessage = "Phường/Xã là bắt buộc.")]
        public string SelectedWard { get; set; }
        public string? Image { get; set; }
        public List<SelectListItem> Cities { get; set; } = new();
        public List<SelectListItem> Districts { get; set; } = new();
        public List<SelectListItem> Wards { get; set; } = new();
    }
}
