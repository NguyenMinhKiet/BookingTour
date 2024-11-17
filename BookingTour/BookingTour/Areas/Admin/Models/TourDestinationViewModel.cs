using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
{
    public class TourDestinationViewModel
    {
        public Guid TourID { get; set; }
        public string TourName { get; set; }
        public Guid DestinationID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày tham quan!")]
        [DataType(DataType.Date, ErrorMessage = "Ngày tham quan không hợp lệ.")]
        public DateTime VisitDate { get; set; }
    }
}
