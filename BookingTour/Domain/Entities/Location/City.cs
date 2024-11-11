using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Location
{
    public class City
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<District> District { get; set; }
    }
}
