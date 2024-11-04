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
        public int employee_id { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Sai định dạng email !!")]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public int position { get; set; }
        [Required]
        public string address { get; set; }

        public virtual ICollection<TourEmployee> TourEmployee { get; set; }
    }
}
