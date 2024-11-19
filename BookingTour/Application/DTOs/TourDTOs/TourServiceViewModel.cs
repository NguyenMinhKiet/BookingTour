using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.TourDTOs
{
    public class TourServiceViewModel
    {
        public int PageNumber { get; set; }
        public int ItemCount { get; set; }
        public List<TourViewModel> Tours { get; set; }
    }
}
