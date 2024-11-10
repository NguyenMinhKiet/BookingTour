using Domain.Entities;
using Infrastructure.Configurations;
using Infrastructure.DataAccess.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourDestination> ToursDestination { get; set; }
        public DbSet<TourEmployee> ToursEmployee { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<Authorized> Authorizeds { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new DestinationConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new TourConfiguration());
            modelBuilder.ApplyConfiguration(new TourDestinationConfiguration());
            modelBuilder.ApplyConfiguration(new TourEmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleGroupConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorizedConfiguration());

            

            base.OnModelCreating(modelBuilder);

            //// Thêm dữ liệu mẫu cho bảng Destinations
            //modelBuilder.Entity<Destination>().HasData(
            //    new Destination
            //    {
            //        DestinationID = Guid.NewGuid(),
            //        Name = "Hạ Long",
            //        City = "Quảng Ninh",
            //        Country = "Việt Nam",
            //        Description = "Vịnh Hạ Long, di sản thiên nhiên thế giới nổi tiếng với các hòn đảo đá vôi."
            //    },
            //    new Destination
            //    {
            //        DestinationID = Guid.NewGuid(),
            //        Name = "Hồ Chí Minh",
            //        City = "Hồ Chí Minh",
            //        Country = "Việt Nam",
            //        Description = "Thành phố Hồ Chí Minh, trung tâm kinh tế và văn hóa lớn nhất Việt Nam."
            //    }
            //);


            //// Thêm dữ liệu mẫu cho bảng Tours
            //modelBuilder.Entity<Tour>().HasData(
            //    new Tour
            //    {
            //        TourID = Guid.NewGuid(),
            //        Title = "Tour Hồ Chí Minh",
            //        Description = "Khám phá thành phố Hồ Chí Minh với các điểm tham quan nổi bật như Chợ Bến Thành, Nhà Thờ Đức Bà.",
            //        Price = 1000000,
            //        StartDate = new DateTime(2024, 11, 10),
            //        EndDate = new DateTime(2024, 11, 12),
            //        AvailableSeats = 20
            //    },
            //    new Tour
            //    {
            //        TourID = Guid.NewGuid(),
            //        Title = "Tour Hạ Long",
            //        Description = "Tham quan vịnh Hạ Long, kỳ quan thiên nhiên của thế giới với các hang động đẹp như Đầu Gỗ, Sung Sốt.",
            //        Price = 2000000,
            //        StartDate = new DateTime(2024, 11, 10),
            //        EndDate = new DateTime(2024, 11, 11),
            //        AvailableSeats = 15
            //    }
            //);


        }
    }
}
