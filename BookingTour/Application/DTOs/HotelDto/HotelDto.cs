using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.HotelDto
{
    public class HotelDto
    {
        public Guid HotelID { get; set; }
        public string Name { get; set; }
        public int StarRating { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }
        public string SelectedCity { get; set; }
        public string SelectedDistrict { get; set; }
        public string SelectedWard { get; set; }
        public List<SelectListItem> Cities { get; set; } = new();
        public List<SelectListItem> Districts { get; set; } = new();
        public List<SelectListItem> Wards { get; set; } = new();
    }
}
