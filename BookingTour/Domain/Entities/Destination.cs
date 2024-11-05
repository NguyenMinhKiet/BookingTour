using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Destination
    {
        public int destination_id { get; set; }
        public string destination_name { get; set; }
        public string description { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        public virtual ICollection<TourDestination> TourDestinations { get; set; }
    }
}
