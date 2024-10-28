using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class Destination
    {
        [Key]
        private int destination_id { get; set; }
        [Required]
        private string destination_name { get; set; }
        [Required]
        [StringLength(100)]
        private string city { get; set; }
        [Required]
        [StringLength(100)]
        private string country { get; set; }
    }
}
