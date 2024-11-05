using Domain.Entities;
using Infrastructure.DataAccess.Configurations;
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

            base.OnModelCreating(modelBuilder);


            // Seed dữ liệu cho bảng Khách hàng
            modelBuilder.Entity<Customer>().HasData(
                new Customer 
                { 
                    customer_id = -1, 
                    first_name = "Nguyễn", 
                    last_name = "Văn A", 
                    email = "nguyenvana@example.com", 
                    phone = "0123456789", 
                    address = "123 Đường Láng" 
                },
                new Customer 
                { 
                    customer_id = -2, 
                    first_name = "Trần", 
                    last_name = "Thị B", 
                    email = "tranthib@example.com", 
                    phone = "0987654321", 
                    address = "456 Phố Huế" 
                }
            );

            // Seed data cho Employees
            // position: 1: Quản lý, 2: Hướng dẫn viên, 3: Tài xế, 5: Admin
            modelBuilder.Entity<Employee>().HasData(

                new Employee
                {
                    employee_id = -4,
                    first_name = "Nguyễn Minh",
                    last_name = "Kiệt",
                    email = "nguyenminhkiet@gmail.com",
                    phone = "0932881172",
                    position = 5,
                    address = "Q12 Tp.HCM"
                },

                new Employee 
                { 
                    employee_id = -1, 
                    first_name = "Lê", 
                    last_name = "Tùng",
                    email = "letung@example.com", 
                    phone = "0123456780", 
                    position = 1, 
                    address = "Hồ Chí Minh" 
                },

                new Employee 
                { 
                    employee_id = -2, 
                    first_name = "Phạm", 
                    last_name = "Hùng", 
                    email = "phamhung@example.com", 
                    phone = "0987654320", 
                    position = 2, 
                    address = "Hà Nội" 
                },

                new Employee
                {
                    employee_id = -3,
                    first_name = "Phạm",
                    last_name = "Linh",
                    email = "phamlinh@example.com",
                    phone = "0987231220",
                    position = 3,
                    address = "Hà Nội"
                }
            );

            // Seed dữ liệu cho bảng Điểm đến
            modelBuilder.Entity<Destination>().HasData(

                new Destination 
                { 
                    destination_id = -1, 
                    destination_name = "Bãi biển Nha Trang", 
                    city = "Nha Trang", 
                    country = "Việt Nam",
                    description = "Một bãi biển nổi tiếng với cát trắng và nước biển trong xanh."
                },

                new Destination 
                { 
                    destination_id = -2, 
                    destination_name = "Đỉnh Fansipan", 
                    city = "Lào Cai", 
                    country = "Việt Nam",
                    description = "Nóc nhà Đông Dương, nơi có phong cảnh hùng vĩ và khí hậu trong lành."
                }
            );

            // Seed dữ liệu cho bảng Tour
            modelBuilder.Entity<Tour>().HasData(

                new Tour
                {
                    tour_id = -1,
                    tour_name = "Du lịch biển",
                    description = "Tour nghỉ dưỡng tại bãi biển",
                    price = 1999000m,
                    start_Date = new DateTime(2024, 1, 15),
                    end_Date = new DateTime(2024, 1, 20),
                    availableSeats = 20
                },

                new Tour
                {
                    tour_id = -2,
                    tour_name = "Thám hiểm núi",
                    description = "Tour leo núi đầy thử thách",
                    price = 2999000m,
                    start_Date = new DateTime(2024, 2, 10),
                    end_Date = new DateTime(2024, 2, 15),
                    availableSeats = 15
                }
            );

            // Seed data cho TourDestinations
            modelBuilder.Entity<TourDestination>().HasData(
                new TourDestination
                {
                    tour_id = -1,
                    destination_id = -1,
                    visit_date = DateTime.Now
                },
                new TourDestination
                {
                    tour_id = -2,
                    destination_id = -2,
                    visit_date = DateTime.Now
                }
            );

            // Seed data cho TourEmployees
            modelBuilder.Entity<TourEmployee>().HasData(

                new TourEmployee
                {
                    tour_id = -1,
                    employee_id = -2,
                },

                new TourEmployee
                {
                    tour_id = -1,
                    employee_id = -3,
                },

                new TourEmployee
                {
                    tour_id = -2,
                    employee_id = -2,
                },

                new TourEmployee
                {
                    tour_id = -2,
                    employee_id = -3,
                }
            );

            // Seed data cho Bookings (must be seeded before Payments)
            modelBuilder.Entity<Booking>().HasData(

                new Booking
                {
                    booking_id = -1,
                    tour_id = -1,
                    customer_id = -1,
                    booking_date = DateTime.Now,
                    num_people = 2,
                    total_price = 3000000
                },

                new Booking
                {
                    booking_id = -2,
                    tour_id = -2,
                    customer_id = -2,
                    booking_date = DateTime.Now,
                    num_people = 1,
                    total_price = 2000000
                }
            );

            // Seed data cho Payments (after Bookings)
            modelBuilder.Entity<Payment>().HasData(

                new Payment
                {
                    payment_id = -1,
                    booking_id = -1,
                    payment_date = DateTime.Now,
                    payment_method = "Tiền mặt"
                },

                new Payment
                {
                    payment_id = -2,
                    booking_id = -2,
                    payment_date = DateTime.Now,
                    payment_method = "Thẻ ví"
                }
            );


            // Seed data cho Feedbacks
            modelBuilder.Entity<Feedback>().HasData(

                new Feedback
                {
                    feedback_id = -1,
                    comments = "Chuyến đi tuyệt vời!",
                    customer_id = -1,
                    rating = 5,
                    tour_id = -1
                },

                new Feedback
                {
                    feedback_id = -2,
                    comments = "Hài lòng với dịch vụ.",
                    customer_id = -2,
                    rating = 4,
                    tour_id = -2
                }
            );

        }
    }
}
