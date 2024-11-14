using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
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

        public string AccountID { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Sai định dạng email, (.. @gmail.com) !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập 10 kí tự số!")]
        [Range(1000000000, 9999999999)]
        public string Phone { get; set; }
    }
}
