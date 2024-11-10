namespace Application.DTOs.EmployeeDTOs
{
    public class EmployeeCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public Guid AccountID { get; set; }
    }
}
