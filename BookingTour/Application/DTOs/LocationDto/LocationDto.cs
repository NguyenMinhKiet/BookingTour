using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.DTOs.LocationDto
{
    public class LocationDto
    {
        public string SelectedCity { get; set; }
        public string SelectedDistrict { get; set; }
        public string SelectedWard { get; set; }
        public List<SelectListItem> Cities { get; set; } = new();
        public List<SelectListItem> Districts { get; set; } = new();
        public List<SelectListItem> Wards { get; set; } = new();
    }

}
