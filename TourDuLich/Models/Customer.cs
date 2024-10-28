using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLich.Models
{
    public class Customer
    {
        [Key]
        private int customer_id { get; set; }
        [Required]
        [StringLength(100)]
        private string first_name { get; set; }
        [Required]
        [StringLength(100)]
        private string last_name { get; set; }
        [Required]
        [EmailAddress]
        private string email { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Phone number cannot be longer than 10 digits.")]
        private string phone { get; set; }
        [Required]
        private string address { get; set; }
    }
}
