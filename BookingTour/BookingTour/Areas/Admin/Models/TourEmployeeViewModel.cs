using Application.DTOs.EmployeeDTOs;
using Domain.Entities;

namespace Presentation.Areas.Admin.Models
{
    public class TourEmployeeViewModel
    {
        public Guid TourID { get; set; }
        public List<TourDetailEmployeeViewModel> Employees { get; set; }

        public Tour Tour { get; set; }
    }
}
