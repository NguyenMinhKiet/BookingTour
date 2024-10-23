using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich.Models
{
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }
        [Required]
        [StringLength(100)]
        public string first_name { get; set; }
        [Required]
        [StringLength(100)]
        public string last_name { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Phone number cannot be longer than 10 digits.")]
        public string phone { get; set; }
        [Required]
        public string address { get; set; }
    }
}
