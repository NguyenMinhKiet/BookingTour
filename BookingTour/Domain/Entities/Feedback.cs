using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Feedback
    {
        [Key]
        public int feedback_id;
        [Required]
        public int customer_id;
        [Required]
        public int tour_id;
        [Required]
        public int rating;
        [Required]
        public string comments;

        public virtual Tour Tour { get; set; }
    }
}
