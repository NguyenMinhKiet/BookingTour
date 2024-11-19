
using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class CustomerViewModel
    {
        public Guid CustomerID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ đệm !")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên !")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ !")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email !")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ. Vd example@gmail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại !")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ. Hãy nhập 10 ký tự số")]
        public string Phone { get; set; }
        
    }
}
