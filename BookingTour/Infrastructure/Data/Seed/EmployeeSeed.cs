using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.Seed
{
    public class EmployeeSeed
    {
        public static async Task SeedEmployeesAsync(ApplicationDbContext context, UserManager<Account> userManager, RoleManager<Role> roleManager)
        {
            // Tạo các role nếu chưa có
            string[] roles = { "Admin", "Manager", "Employee", "User" };
            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new Role(role, role + "Role"));
                }
            }

            if (!context.Users.Any())
            {
                // Danh sách tài khoản và mật khẩu
                var usersWithRoles = new List<(Account user, string password, string role)>
    {
        (new Account { UserName = "admin", Email = "nguyenminhkiet642002@gmail.com", Phone = "0932667135", isActive = true, Password = "Kiet123", SecurityStamp = Guid.NewGuid().ToString() }, "Kiet123", "Admin"),
        (new Account { UserName = "manager", Email = "manager@example.com", Phone = "0123456789", isActive = true,Password = "Manager123", SecurityStamp = Guid.NewGuid().ToString() }, "Manager123", "Manager"),
        (new Account { UserName = "tourguide1", Email = "tourguide1@example.com", Phone = "0987654321", isActive = true,Password="TourGuide123", SecurityStamp = Guid.NewGuid().ToString() }, "TourGuide123", "Employee"),
        (new Account { UserName = "tourguide2", Email = "tourguide2@example.com", Phone = "0912345678", isActive = true,Password = "TourGuide123", SecurityStamp = Guid.NewGuid().ToString() }, "TourGuide123", "Employee"),
        (new Account { UserName = "driver1", Email = "driver1@example.com", Phone = "0923456789", isActive = true,Password="Driver123", SecurityStamp = Guid.NewGuid().ToString() }, "Driver123", "Employee"),
        (new Account { UserName = "driver2", Email = "driver2@example.com", Phone = "0934567890", isActive = true,Password="Driver123", SecurityStamp = Guid.NewGuid().ToString() }, "Driver123", "Employee"),
        (new Account { UserName = "customer1", Email = "customer1@example.com", Phone = "0987654321", isActive = true,Password="Customer123", SecurityStamp = Guid.NewGuid().ToString() }, "Customer123", "User"),
        (new Account { UserName = "customer2", Email = "customer2@example.com", Phone = "0912345678", isActive = true,Password="Customer123", SecurityStamp = Guid.NewGuid().ToString() }, "Customer123", "User"),
        (new Account { UserName = "customer3", Email = "customer3@example.com", Phone = "0923456789", isActive = true,Password="Customer123", SecurityStamp = Guid.NewGuid().ToString() }, "Customer123", "User")
    };

                // Thêm tài khoản và gán vai trò
                foreach (var (user, password, role) in usersWithRoles)
                {
                    if (await userManager.FindByNameAsync(user.UserName) == null)
                    {
                        var createUserResult = await userManager.CreateAsync(user, password);
                        if (createUserResult.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, role);
                        }
                        else
                        {
                            Console.WriteLine($"Failed to create user {user.UserName}: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");
                        }
                    }
                }
            }


            // Kiểm tra xem bảng Employees đã có dữ liệu chưa
            if (!context.Employees.Any())
            {
                var employees = new List<Employee>
                {
                    new Employee
                    {
                        EmployeeID = Guid.NewGuid(),
                        FirstName = "Nguyễn Minh",
                        LastName = "Kiệt",
                        Address = "160 Huỳnh Thị Hai Q12, HCM",
                        Position = "Manager",
                        Email = "nguyenminhkiet64200@gmail.com",
                        Phone = "0988777222",
                        AccountID = context.Users.FirstOrDefault(u => u.UserName == "admin")?.Id ?? Guid.Empty,
                        Image = "bi_tot_nghiep_cut.png" 
                    },
                    new Employee
                    {
                        EmployeeID = Guid.NewGuid(),
                        FirstName = "Quang",
                        LastName = "Hưng",
                        Address = "123 Phố Quang Trung, Hà Nội",
                        Position = "Manager",
                        Email = "manager@example.com",
                        Phone = "0123456789",
                        // Sử dụng FirstOrDefault để tránh lỗi khi không tìm thấy người dùng
                        AccountID = context.Users.FirstOrDefault(u => u.UserName == "manager")?.Id ?? Guid.Empty,
                        Image = "female_default.png" // Chỉ lưu tên tệp hình ảnh
                    },
                    new Employee
                    {
                        EmployeeID = Guid.NewGuid(),
                        FirstName = "Tuấn",
                        LastName = "Anh",
                        Address = "456 Phố Hàng Bông, Hà Nội",
                        Position = "Tour Guide",
                        Email = "tourguide1@example.com",
                        Phone = "0987654321",
                        // Sử dụng FirstOrDefault để tránh lỗi khi không tìm thấy người dùng
                        AccountID = context.Users.FirstOrDefault(u => u.UserName == "tourguide1")?.Id ?? Guid.Empty,
                        Image = "male_default.png" // Chỉ lưu tên tệp hình ảnh
                    },
                    new Employee
                    {
                        EmployeeID = Guid.NewGuid(),
                        FirstName = "Thành",
                        LastName = "Vũ",
                        Address = "789 Phố Đinh Tiên Hoàng, Hà Nội",
                        Position = "Tour Guide",
                        Email = "tourguide2@example.com",
                        Phone = "0912345678",
                        // Sử dụng FirstOrDefault để tránh lỗi khi không tìm thấy người dùng
                        AccountID = context.Users.FirstOrDefault(u => u.UserName == "tourguide2")?.Id ?? Guid.Empty,
                        Image = "male_default.png" // Chỉ lưu tên tệp hình ảnh
                    },
                    new Employee
                    {
                        EmployeeID = Guid.NewGuid(),
                        FirstName = "Linh",
                        LastName = "Nguyễn",
                        Address = "101 Phố Lê Duẩn, Hà Nội",
                        Position = "Driver",
                        Email = "driver1@example.com",
                        Phone = "0923456789",
                        // Sử dụng FirstOrDefault để tránh lỗi khi không tìm thấy người dùng
                        AccountID = context.Users.FirstOrDefault(u => u.UserName == "driver1")?.Id ?? Guid.Empty,
                        Image = "male_default.png" // Chỉ lưu tên tệp hình ảnh
                    },
                    new Employee
                    {
                        EmployeeID = Guid.NewGuid(),
                        FirstName = "Bảo",
                        LastName = "Lê",
                        Address = "202 Phố Trần Quang Khải, Hà Nội",
                        Position = "Driver",
                        Email = "driver2@example.com",
                        Phone = "0934567890",
                        // Sử dụng FirstOrDefault để tránh lỗi khi không tìm thấy người dùng
                        AccountID = context.Users.FirstOrDefault(u => u.UserName == "driver2")?.Id ?? Guid.Empty,
                        Image = "male_default.png" // Chỉ lưu tên tệp hình ảnh
                    }
                };

                // Thêm danh sách nhân viên vào cơ sở dữ liệu
                await context.Employees.AddRangeAsync(employees);
                await context.SaveChangesAsync();
            }

            // Kiểm tra xem bảng Customers đã có dữ liệu chưa
            if (!context.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new Customer
                    {
                        CustomerID = Guid.NewGuid(),
                        FirstName = "Hà",
                        LastName = "Nguyễn",
                        Email = "customer1@example.com",
                        Address = "123 Phố Minh Khai, Hà Nội",
                        Phone = "0987654321",
                        AccountID = context.Users.First(u => u.UserName == "customer1").Id,
                        Image = "female_default.png" // Chỉ lưu tên tệp hình ảnh
                    },
                    new Customer
                    {
                        CustomerID = Guid.NewGuid(),
                        FirstName = "Hùng",
                        LastName = "Trần",
                        Email = "customer2@example.com",
                        Address = "456 Phố Nguyễn Trãi, Hà Nội",
                        Phone = "0912345678",
                        AccountID = context.Users.First(u => u.UserName == "customer2").Id,
                        Image = "male_default.png" // Chỉ lưu tên tệp hình ảnh
                    },
                    new Customer
                    {
                        CustomerID = Guid.NewGuid(),
                        FirstName = "Lan",
                        LastName = "Lê",
                        Email = "customer3@example.com",
                        Address = "789 Phố Lê Lợi, Hà Nội",
                        Phone = "0923456789",
                        AccountID = context.Users.First(u => u.UserName == "customer3").Id,
                        Image = "female_default.png" // Chỉ lưu tên tệp hình ảnh
                    }
                };

                // Thêm danh sách khách hàng vào cơ sở dữ liệu
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
            }
        }
    }
}
