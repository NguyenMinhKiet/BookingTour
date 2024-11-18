using Application.DTOs.DestinationDTOs;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
{
    public class TourDestinationViewModel
    {
        public Guid TourID { get; set; }
        public string TourName { get; set; }
        public List<DestinationWithVisitDateViewModel> Destinations { get; set; } 

    }
}
