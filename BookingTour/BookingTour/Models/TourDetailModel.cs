using Application.DTOs.DestinationDTOs;
using Application.DTOs.FeedbackDTOs;
using Application.DTOs.HotelDto;
using Application.DTOs.TourDTOs;

namespace Presentation.Models
{
    public class TourDetailModel
    {
        public Guid TourID {  get; set; }
        public Guid CustomerID { get; set; }
        public string TourName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }

        public List<DestinationWithVisitDateViewModel> Destinations { get; set; }
        public List<TourViewModel> TourBookings { get; set; }
        public List<TourViewModel> AnotherTour { get; set; }
        public List<HotelModel> Hotels { get; set; }
        public List<FeedbackViewModel> Feedbacks { get; set; }  
    }
}
