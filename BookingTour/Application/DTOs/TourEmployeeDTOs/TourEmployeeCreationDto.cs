using Domain.Entities;

namespace Application.DTOs.TourEmployeeDTOs
{
    public class TourEmployeeCreationDto
    {
        public Guid TourID { get; set; }
        public Guid EmployeeID { get; set; }
    }
}
