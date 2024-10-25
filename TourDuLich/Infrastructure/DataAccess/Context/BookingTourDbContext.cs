using Microsoft.EntityFrameworkCore;
using TourDuLich.Infrastructure.DataAccess.Configurations;
using TourDuLich.Models;

namespace TourDuLich.Infrastructure.DataAccess.Context
{
    public class BookingTourDbContext: DbContext
    {
        public BookingTourDbContext(DbContextOptions<BookingTourDbContext> options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourDestination> ToursDestination { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new DestinationConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new TourConfiguration());
            modelBuilder.ApplyConfiguration(new TourDestinationConfiguration());

            base.OnModelCreating(modelBuilder);

        }

    }
}
