using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Nhập tên người dùng.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
