using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class CustomerViewModel
    {
        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AccountID { get; set; }
    }
}
