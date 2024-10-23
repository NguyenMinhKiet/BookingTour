using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
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
        [StringLength(100)]
        public string position {  get; set; }
        [Required]
        public string address { get; set; }

    }
}
