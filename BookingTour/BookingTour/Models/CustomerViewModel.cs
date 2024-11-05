using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class CustomerViewModel
    {
        public int customer_id { get; set; }

        [Display(Name = "Họ đệm")]
        public string first_name { get; set; }
        [Display(Name = "Tên")]
        public string last_name { get; set; }
        public string email { get; set; }
        

        [StringLength(10, MinimumLength = 10, ErrorMessage = "Số điện thoại phải có đúng 10 ký tự.")]
        public string phone { get; set; }
        public string address { get; set; }

        public string full_name {  get; set; }
    }
}
