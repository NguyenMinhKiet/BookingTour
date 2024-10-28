namespace TourDuLich.Domain.Entities
{
    public class Tour
    {
        private int tour_id { get; set; }
        private string tour_name { get; set; }
        private string description { get; set; }
        private decimal price { get; set; }
        private DateTime start_Date { get; set; }
        private DateTime end_Date { get; set; }
    }
}
