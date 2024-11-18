using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.FeedbackDTOs
{
    public class FeedbackCreationDto
    {
        public Guid CustomerID { get; set; }
        public Guid TourID { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Comments cannot exceed 500 characters.")]
        public string Comments { get; set; }
    }
}
