using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EmployeeDTOs
{
    public class EmployeeCreationDto
    {

        [Required(ErrorMessage = "Vui lòng nhập họ đệm!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn vị trí!")]
        public string Position { get; set; }

        public string? AccountID { get; set; } 

        [Required(ErrorMessage = "Vui lòng nhập email!")]
        [EmailAddress(ErrorMessage = "Sai định dạng email, ví dụ: example@gmail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại!")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Vui lòng nhập 10 ký tự số!")]
        public string Phone { get; set; }
    }
}
