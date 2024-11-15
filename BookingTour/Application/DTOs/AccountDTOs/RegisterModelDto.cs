using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AccountDTOs
{
    public class RegisterModelDto
    {
        [Required]
        public string Username { get; set; }

        [Required(ErrorMessage = "Nhập mật khẩu.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Nhập lại mật khẩu.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng với mật khẩu đã nhập")]
        public string ConfirmPassword { get; set; }



        [Required(ErrorMessage = "Vui lòng nhập email!")]
        [EmailAddress(ErrorMessage = "Sai định dạng email, ví dụ: example@gmail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại!")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Vui lòng nhập 10 ký tự số!")]
        public string Phone { get; set; }


        public bool isActive { get; set; }
    }
}
