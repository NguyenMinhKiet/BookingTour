using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int position { get; set; }
        public string address { get; set; }
        public Guid AccountID { get; set; }

        public virtual ICollection<TourEmployee> TourEmployee { get; set; }
    }
}
