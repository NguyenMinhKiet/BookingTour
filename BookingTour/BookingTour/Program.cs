using Application.Services;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Specialized;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default_Connection")));



// Đăng ký các repository
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<ITourDestinationRepository, TourDestinationRepository>();
builder.Services.AddScoped<ITourEmployeeRepository, TourEmployeeRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleGroupRepository, RoleGroupRepository>();
builder.Services.AddScoped<IAuthorizedRepository, AuthorizedRepository>();


// Đăng ký các service
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDestinationService, DestinationService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ITourService, TourService>();
builder.Services.AddScoped<ITourDestinationService, TourDestinationService>();
builder.Services.AddScoped<ITourEmployeeService, TourEmployeeService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleGroupService, RoleGroupService>();
builder.Services.AddScoped<IAuthorizedService, AuthorizedService>();
builder.Services.AddScoped<ILocationService, LocationService>();

// Add TempData
builder.Services.AddControllersWithViews()
    .AddSessionStateTempDataProvider();

// Cấu hình các dịch vụ (ConfigureServices)
builder.Services.AddDistributedMemoryCache(); // Đăng ký dịch vụ cache trong bộ nhớ, session sẽ sử dụng nó
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "MinhKiet"; // Đặt tên cookie cho session
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Thời gian tồn tại của session
});

// Thêm logging vào console
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

// Cấu hình route cho các Area
app.UseEndpoints(endpoints =>
{
    // Cấu hình cho các Area
    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


    // Cấu hình cho các controller không thuộc Area

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});





app.Run();

