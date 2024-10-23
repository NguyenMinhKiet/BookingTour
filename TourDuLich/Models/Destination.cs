using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class Destination
    {
        [Key]
        public int destination_id { get; set; }
        [Required]
        public string destination_name { get; set; }
        [Required]
        [StringLength(100)]
        public string city {  get; set; }
        [Required]
        [StringLength(100)]
        public string country { get; set; }
    }
}
