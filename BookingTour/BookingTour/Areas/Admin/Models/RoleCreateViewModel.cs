using System.ComponentModel.DataAnnotations;

namespace Presentation.Areas.Admin.Models
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Tên không được để trống.")]
        public string Name { get; set; }

    }
}
