namespace Presentation.Models
{
    public class AccountViewModel
    {
        public Guid AccountID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid GroupID { get; set; }
        public DateTime CreateAt { get; set; }
        public bool isActive { get; set; }
    }
}
