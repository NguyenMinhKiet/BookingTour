using Application.DTOs.DestinationDTOs;
using Domain.Entities;

namespace Presentation.Areas.Admin.Models
{
    public class TourDestinationViewModel
    {
        public Guid TourID { get; set; }
        public List<DestinationWithVisitDateViewModel> Destinations { get; set; } 
        public virtual Tour Tour { get; set; }

    }
}
