using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.CustomerDTOs
{
    public class CustomerUpdateDto
    {
        [Required(ErrorMessage = "Vui lòng nhập họ đệm !")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên !")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ !")]
        public string Address { get; set; }
    }
}
