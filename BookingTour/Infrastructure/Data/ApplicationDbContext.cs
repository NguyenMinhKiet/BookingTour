using DataAccess.Configurations;
using Domain.Entities;
using Infrastructure.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }


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
            modelBuilder.ApplyConfiguration(new TourEmployeeConfiguration());

            base.OnModelCreating(modelBuilder);


        }

        public async Task SeedDataAsync()
        {
            // Kiểm tra xem bảng Customer có dữ liệu không
            if (!Customers.Any())
            {
                var customers = new List<Customer>
            {
                new Customer
                {
                    first_name = "Nguyễn Văn",
                    last_name = "A",
                    email = "nguyenvana@example.com",
                    phone = "0123456789",
                    address = "123 Đường A, Phường B, Quận C"
                },
                new Customer
                {
                    first_name = "Trần Thị",
                    last_name = "B",
                    email = "tranthib@example.com",
                    phone = "0987654321",
                    address = "456 Đường D, Phường E, Quận F"
                },
                new Customer
                {
                    first_name = "Lê Văn",
                    last_name = "C",
                    email = "levanc@example.com",
                    phone = "1234567890",
                    address = "789 Đường G, Phường H, Quận I"
                },
                new Customer
                {
                    first_name = "Phạm Thị",
                    last_name = "D",
                    email = "phamthid@example.com",
                    phone = "2345678901",
                    address = "321 Đường J, Phường K, Quận L"
                },
                new Customer
                {
                    first_name = "Đinh Văn",
                    last_name = "E",
                    email = "dinhve@example.com",
                    phone = "3456789012",
                    address = "654 Đường M, Phường N, Quận O"
                }
            };

                // Thêm dữ liệu vào DbSet
                await Customers.AddRangeAsync(customers);
                await SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            }

            if (!await Employees.AnyAsync())
            {
                var employees = new List<Employee>
            {
                new Employee
                {
                    first_name = "Nguyễn Văn",
                    last_name = "A",
                    email = "nguyenvana@example.com",
                    phone = "0123456789",
                    position = 1, // Ví dụ: 1 có thể là quản lý
                    address = "123 Đường A, Phường B, Quận C"
                },
                new Employee
                {
                    first_name = "Trần Thị",
                    last_name = "B",
                    email = "tranthib@example.com",
                    phone = "0987654321",
                    position = 2, // Ví dụ: 2 có thể là nhân viên
                    address = "456 Đường D, Phường E, Quận F"
                },
                new Employee
                {
                    first_name = "Lê Văn",
                    last_name = "C",
                    email = "levanc@example.com",
                    phone = "1234567890",
                    position = 3, // Ví dụ: 3 có thể là trợ lý
                    address = "789 Đường G, Phường H, Quận I"
                },
                new Employee
                {
                    first_name = "Phạm Thị",
                    last_name = "D",
                    email = "phamthid@example.com",
                    phone = "2345678901",
                    position = 1, // Ví dụ: 1 có thể là quản lý
                    address = "321 Đường J, Phường K, Quận L"
                },
                new Employee
                {
                    first_name = "Đinh Văn",
                    last_name = "E",
                    email = "dinhve@example.com",
                    phone = "3456789012",
                    position = 2, // Ví dụ: 2 có thể là nhân viên
                    address = "654 Đường M, Phường N, Quận O"
                }
            };

                await Employees.AddRangeAsync(employees);
                await SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }
}
