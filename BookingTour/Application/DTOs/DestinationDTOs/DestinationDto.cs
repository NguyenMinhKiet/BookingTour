﻿
namespace Application.DTOs.DestinationDTOs
{
    public class DestinationDto
    {
        public Guid DestinationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }

    }
}