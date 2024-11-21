using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class Account : IdentityUser<Guid>
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isActive { get; set; }


    }
}
