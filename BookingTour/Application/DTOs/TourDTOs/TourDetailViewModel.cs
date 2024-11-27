using Application.DTOs.DestinationDTOs;
using Application.DTOs.EmployeeDTOs;

namespace Application.DTOs.TourDTOs
{
    public class TourDetailViewModel
    {
        public Guid TourID { get; set; }
        public string TourName { get; set; }
        public List<DestinationWithVisitDateViewModel> Destinations { get; set; }
        public List<TourDetailEmployeeViewModel> Employees { get; set; }
    }
}
