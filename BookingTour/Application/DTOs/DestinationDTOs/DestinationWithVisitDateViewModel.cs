﻿using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.DestinationDTOs
{
    public class DestinationWithVisitDateViewModel
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
        [Required(ErrorMessage = "Vui lòng nhập ngày tham quan!")]
        [DataType(DataType.Date, ErrorMessage = "Ngày tham quan không hợp lệ.")]
        public DateTime visitDate { get; set; }
    }
}