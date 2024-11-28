using Application.PermissionRequirement;
using Application.Services;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Seed;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Static;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình dịch vụ xác thực và phân quyền
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    }); 

// Cấu hình Identity
builder.Services.AddIdentity<Account, Role>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

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
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<ITourHotelRepository, TourHotelRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
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
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<ITourHotelService, TourHotelService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

// Đăng ký các seed data
builder.Services.AddScoped<RoleSeed>();
builder.Services.AddScoped<TourSeed>();
builder.Services.AddScoped<DestinationSeed>();
builder.Services.AddScoped<HotelSeed>();
builder.Services.AddScoped<EmployeeSeed>();

// Cấu hình Authorization
builder.Services.AddAuthorization(options =>
{
    var permissions = new[] {
    PERMISSIONS.USER_GROUP_VIEW,
    PERMISSIONS.USER_GROUP_ADD,
    PERMISSIONS.USER_GROUP_UPDATE,
    PERMISSIONS.USER_GROUP_DELETE,

    PERMISSIONS.ACCOUNT_VIEW,
    PERMISSIONS.ACCOUNT_ADD,
    PERMISSIONS.ACCOUNT_UPDATE,
    PERMISSIONS.ACCOUNT_DELETE,
    PERMISSIONS.ACCOUNT_BLOCK,

    PERMISSIONS.CUSTOMER_VIEW,
    PERMISSIONS.CUSTOMER_ADD,
    PERMISSIONS.CUSTOMER_UPDATE,
    PERMISSIONS.CUSTOMER_DELETE,

    PERMISSIONS.EMPLOYEE_VIEW,
    PERMISSIONS.EMPLOYEE_ADD,
    PERMISSIONS.EMPLOYEE_UPDATE,
    PERMISSIONS.EMPLOYEE_DELETE,

    PERMISSIONS.DESTINATION_VIEW,
    PERMISSIONS.DESTINATION_ADD,
    PERMISSIONS.DESTINATION_UPDATE,
    PERMISSIONS.DESTINATION_DELETE,

    PERMISSIONS.TOUR_VIEW,
    PERMISSIONS.TOUR_ADD,
    PERMISSIONS.TOUR_UPDATE,
    PERMISSIONS.TOUR_DELETE,

    PERMISSIONS.TOUR_DESTINATION_VIEW,
    PERMISSIONS.TOUR_DESTINATION_ADD,
    PERMISSIONS.TOUR_DESTINATION_UPDATE,
    PERMISSIONS.TOUR_DESTINATION_DELETE,

    PERMISSIONS.TOUR_EMPLOYEE_VIEW,
    PERMISSIONS.TOUR_EMPLOYEE_ADD,
    PERMISSIONS.TOUR_EMPLOYEE_UPDATE,
    PERMISSIONS.TOUR_EMPLOYEE_DELETE,

    PERMISSIONS.BOOKING_VIEW,
    PERMISSIONS.BOOKING_ADD,
    PERMISSIONS.BOOKING_UPDATE,
    PERMISSIONS.BOOKING_DELETE,

    PERMISSIONS.PAYMENT_VIEW,
    PERMISSIONS.PAYMENT_ADD,
    PERMISSIONS.PAYMENT_UPDATE,
    PERMISSIONS.PAYMENT_DELETE,

    PERMISSIONS.FEEDBACK_VIEW,
    PERMISSIONS.FEEDBACK_ADD,
    PERMISSIONS.FEEDBACK_UPDATE,
    PERMISSIONS.FEEDBACK_DELETE,

    PERMISSIONS.ROLE_VIEW,
    PERMISSIONS.ROLE_ADD,
    PERMISSIONS.ROLE_UPDATE,
    PERMISSIONS.ROLE_DELETE,
    PERMISSIONS.ROLE_CHANGE,

    PERMISSIONS.ROLE_Claim_VIEW,
    PERMISSIONS.ROLE_Claim_ADD,
    PERMISSIONS.ROLE_Claim_UPDATE,
    PERMISSIONS.ROLE_Claim_DELETE,

    PERMISSIONS.PROFILE_UPDATE,
    PERMISSIONS.PROFILE_VIEW
};


    foreach (var permission in permissions)
    {
        options.AddPolicy(permission, policy =>
            policy.Requirements.Add(new PermissionRequirement(permission)));
    }

    options.AddPolicy("RequiredAdminOrManager", policy => policy.RequireRole("Admin", "Manager"));
});

builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

// Cấu hình logging
builder.Services.AddLogging();
builder.Services.AddControllersWithViews()
    .AddSessionStateTempDataProvider();

// Cấu hình session và cache
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "MinhKiet";
    options.IdleTimeout = TimeSpan.FromHours(2);
    options.Cookie.IsEssential = true;
});

// Cấu hình HTTP request pipeline
var app = builder.Build();

// Cấu hình các middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

// Cấu hình các routes
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapGet("/readname", async (context) =>
    {
        string? count;
        count = context.Session.GetString("UserID");

        if(count == null)
        {
            count = "N/A";
        }
        await context.Response.WriteAsync($"tên w: {count}");
    });
});
// Khởi tạo Seed Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    var roleSeed = services.GetRequiredService<RoleSeed>();
    await roleSeed.SeedRolesAsync();

    var userManager = services.GetRequiredService<UserManager<Account>>();
    var roleManager = services.GetRequiredService<RoleManager<Role>>();

    DestinationSeed.SeedDestinationsAsync(context).Wait();
    TourSeed.SeedToursAsync(context).Wait();
    HotelSeed.SeedHotelsAsync(context).Wait();

    EmployeeSeed.SeedEmployeesAsync(context,userManager, roleManager).Wait();
}

app.Run();
