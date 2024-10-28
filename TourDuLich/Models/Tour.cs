using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class Tour
    {
        [Key]
        private int tour_id { get; set; }
        [Required]
        [StringLength(200)]
        private string tour_name { get; set; }
        [Required]
        private string description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        private decimal price { get; set; }
        [Required]
        private DateTime start_Date { get; set; }
        [Required]
        private DateTime end_Date { get; set; }
        [Required]
        private int available_seats { get; set; }
    }
}
