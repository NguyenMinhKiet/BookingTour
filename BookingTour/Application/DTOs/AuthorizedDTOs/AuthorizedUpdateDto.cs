using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AuthorizedDTOs
{
    public class AuthorizedUpdateDto
    {
        public Guid AccountID { get; set; }
        public Guid GroupID { get; set; }
    }
}
