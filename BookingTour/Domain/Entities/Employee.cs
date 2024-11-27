namespace Domain.Entities
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string? Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid AccountID { get; set; }

        public virtual ICollection<TourEmployee> TourEmployee { get; set; }
        public virtual Account Account { get; set; }
    }
}
