using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TourHotel
    {
        public Guid TourID { get; set; }
        public Tour Tour { get; set; }
        public Guid HotelID { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
