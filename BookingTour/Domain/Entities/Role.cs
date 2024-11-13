
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
