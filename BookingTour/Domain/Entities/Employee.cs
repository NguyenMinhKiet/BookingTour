using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        [Key]
        [Display(Name = "Mã nhân viên")]
        public int employee_id { get; set; }
        [Display(Name = "Họ")]
        [MaxLength(100)]
        public string first_name { get; set; }
        [Display(Name = "Tên")]
        [MaxLength(50)]
        public string last_name { get; set; }
        public string email { get; set; }
        [Display(Name = "Số điện thoại")]
        [MaxLength(10)]
        public string phone { get; set; }
        [Display(Name = "Chức vụ")]
        [MaxLength(100)]
        public string position { get; set; }
        [Display(Name = "Địa chỉ")]
        [MaxLength(150)]
        public string address { get; set; }
    }
}
