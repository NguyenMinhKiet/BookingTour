using Microsoft.AspNetCore.Mvc.Rendering;
namespace Application.DTOs.RoleDTOs
{
    public class RoleChangeViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string CurrentRole { get; set; }
        public List<SelectListItem> Roles { get; set; } // Danh sách các roles
    }

}
