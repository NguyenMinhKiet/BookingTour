using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.HotelDto
{
    public class HotelDto
    {
        public Guid HotelID { get; set; }
        public string Name { get; set; }
        public int Star { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
