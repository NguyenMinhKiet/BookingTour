namespace Application.DTOs.CustomerDTOs
{
    public class CustomerCreationDto
    {
        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Guid AccountID { get; set; }
    }
}
