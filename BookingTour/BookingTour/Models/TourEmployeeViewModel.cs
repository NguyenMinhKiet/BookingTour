using Domain.Entities;

namespace Presentation.Models
{
    public class TourEmployeeViewModel
    {
        public int tour_id { get; set; }
        public int employee_id { get; set; }

        public string employee_name { get; set; }
        public string position { get; set; }
       
    }
}
