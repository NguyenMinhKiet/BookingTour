using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.TourDestinationDTOs
{
    public class TourDestinationUpdateViewModel
    {
        public Guid TourID { get; set; }
        public Guid DestinationID { get; set; }
        public DateTime  VisitDate { get; set; }
    }
}
