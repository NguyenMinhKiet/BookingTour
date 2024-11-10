using Domain.Entities;

namespace Presentation.Models
{
    public class TourEmployeeViewModel
    {
        public Guid TourID { get; set; }
        public Guid EmployeeID { get; set; }

        public string Name {  get; set; }
        public string Position {  get; set; }

    }
}
