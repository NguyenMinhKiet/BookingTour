using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AuthorizedDTOs
{
    public class AuthorizedCreateDto
    {
        public Guid Id { get; set; }
        public Guid AccountID { get; set; }
        public Guid GroupID { get; set; }
    }
}
