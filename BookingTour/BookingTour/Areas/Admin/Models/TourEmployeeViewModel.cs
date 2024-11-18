using Application.DTOs.EmployeeDTOs;

namespace Presentation.Areas.Admin.Models
{
    public class TourEmployeeViewModel
    {
        public Guid TourID { get; set; }
        public string TourName { get; set; }
        public List<TourDetailEmployeeViewModel> Employees { get; set; }
    }
}
