using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
{
    public class AccountViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng mật khẩu!")]
        public string Password { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Sai định dạng email, (.. @gmail.com) !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập 10 kí tự số!")]
        [Range(1000000000, 9999999999)]
        public string Phone { get; set; }

        public List<string> Roles { get; set; }
        public bool isActive { get; set; }
    }
}
