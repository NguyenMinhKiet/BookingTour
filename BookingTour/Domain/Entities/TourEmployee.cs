using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TourEmployee
    {
        public Guid TourID { get; set; }
        public Guid EmployeeID { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
