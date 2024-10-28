namespace TourDuLich.Domain.Entities
{
    public class TourEmployee
    {
        public int tourEmployeeId { get; set; }
        public int tourId { get; set; }
        public int employeeId { get; set; }
        public string position { get; set; }
    }
}
