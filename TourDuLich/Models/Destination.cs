using System.ComponentModel.DataAnnotations;

namespace TourDuLich.Models
{
    public class Destination
    {
        public int destination_id { get; set; }
        public string destination_name { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}
