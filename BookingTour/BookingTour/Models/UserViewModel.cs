
namespace Presentation.Models
{
    public class UserViewModel 
    {
        public required string UniqueID { get; set; }
        public required string UserGroupID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsHost { get; set; }
        public string SessionPermission { get; set; }
    }
}
