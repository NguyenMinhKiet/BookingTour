using System.ComponentModel.DataAnnotations;

namespace Areas.Admin.Models
{
    public class EmployeeViewModel
    {
        public Guid EmployeeID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ đệm !")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên !")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ !")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn vị trí")]
        public string Position { get; set; }

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
