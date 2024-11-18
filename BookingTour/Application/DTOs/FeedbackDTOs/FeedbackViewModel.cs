using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FeedbackDTOs
{
    public class FeedbackViewModel
    {
        public Guid FeedbackID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid TourID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập đánh giá !")]
        [Range(1, 5, ErrorMessage = "Đánh giá phải trong khoảng từ 1 đến 5.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nhận xét !")]
        [StringLength(500, ErrorMessage = "Nhận xét không quá 500 ký tự.")]
        public string Comments { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
