using Application.DTOs.DestinationDTOs;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
{
    public class TourDestinationViewModel
    {
        public Guid TourID { get; set; }
        public string TourName { get; set; }
        public Guid DestinationID { get; set; }
        public DateTime VisitDate { get; set; }

    }
}
