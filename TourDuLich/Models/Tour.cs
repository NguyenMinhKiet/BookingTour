using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class Tour
    {
        [Key]
        public int tour_id { get; set; }
        [Required]
        [StringLength(200)]
        public string tour_name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal price { get; set; }
        [Required]
        public DateTime start_Date { get; set; }
        [Required]
        public DateTime end_Date { get; set; }
    }
}
