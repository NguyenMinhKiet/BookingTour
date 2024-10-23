using Microsoft.EntityFrameworkCore;

namespace TourDuLich.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Tour> Tour { get; set; }
    }
}
