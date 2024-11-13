namespace Application.DTOs.DestinationDTOs
{
    public class DestinationCreationDto
    {
        public Guid DestinationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }

        public string City { get; set; }
    }
}
