using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class Employee
    {
        [Key]
        private int employee_id { get; set; }
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
        [StringLength(100)]
        private string position { get; set; }
        [Required]
        private string address { get; set; }

    }
}
