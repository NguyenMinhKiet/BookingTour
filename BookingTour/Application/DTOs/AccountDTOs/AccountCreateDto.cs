using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AccountDTOs
{
    public class AccountCreateDto
    {
        public Guid AccountID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập xác nhận mật khẩu!")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Sai định dạng email, (.. @gmail.com) !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập 10 kí tự số!")]
        [Range(1000000000, 9999999999)]
        public string Phone { get; set; }
        public bool isActive { get; set; }
    }
}
