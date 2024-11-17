using Application.DTOs.DestinationDTOs;
using Application.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
