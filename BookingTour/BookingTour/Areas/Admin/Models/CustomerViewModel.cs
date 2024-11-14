
using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
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
        public Guid AccountID { get; set; }
        
    }
}
