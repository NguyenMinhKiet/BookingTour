using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AccountDTOs
{
    public class LoginModelDto
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}
