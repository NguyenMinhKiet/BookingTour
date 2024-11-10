namespace Presentation.Models
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isActive { get; set; }
    }
}
