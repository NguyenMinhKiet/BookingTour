using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Destination
    {
        [Key]
        public int destination_id { get; set; }
        [Required]
        public string destination_name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string country { get; set; }

        public virtual ICollection<TourDestination> TourDestinations { get; set; }
    }
}
