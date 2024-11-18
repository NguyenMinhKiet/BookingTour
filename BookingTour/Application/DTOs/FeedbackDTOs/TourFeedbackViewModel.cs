using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.FeedbackDTOs
{
    public class TourFeedbackViewModel
    {
        public Guid TourID { get; set; }
        public string TourName { get; set;}
        public List<FeedbackViewModel> Feedbacks { get; set; }
    }
}
