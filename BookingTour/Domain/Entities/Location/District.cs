using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Location
{
    public class District
    {
        public string Name {  get; set; }
        public string Pre { get; set; }
        public List<Ward> Ward { get; set; }
    }
}
