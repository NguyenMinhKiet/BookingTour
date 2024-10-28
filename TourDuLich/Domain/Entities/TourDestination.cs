namespace TourDuLich.Domain.Entities
{
    public class TourDestination
    {
        private int tourDestination_id { get; set; }
        private int tour_id { get; set; }
        private int destination_id { get; set; }
        private DateTime visit_date { get; set; }
    }
}
