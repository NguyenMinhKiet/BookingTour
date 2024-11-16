using Application.Services;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Seed;
using Infrastructure.Repositories;
using Infrastructure.Static;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ xác thực và phân quyền
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Đường dẫn đến trang login khi người dùng chưa đăng nhập
        options.LoginPath = "/Account/Login";
        // Đường dẫn đến trang logout sau khi người dùng đăng xuất
        options.LogoutPath = "/Account/Logout";
        // Đường dẫn đến trang khi người dùng truy cập vào các trang bị cấm
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

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

builder.Services.AddScoped<RoleSeed>();
builder.Services.AddScoped<AccountAdminSeed>();
builder.Services.AddScoped<TourSeed>();
builder.Services.AddScoped<DestinationSeed>();

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
builder.Services.AddLogging();
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
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireEmployeeRole", policy => policy.RequireRole("Employee"));

    options.AddPolicy("user-group-view", policy => policy.RequireClaim("permission", PERMISSIONS.USER_GROUP_VIEW));
    options.AddPolicy("user-group-add", policy => policy.RequireClaim("permission", PERMISSIONS.USER_GROUP_ADD));
    options.AddPolicy("user-group-update", policy => policy.RequireClaim("permission", PERMISSIONS.USER_GROUP_UPDATE));
    options.AddPolicy("user-group-delete", policy => policy.RequireClaim("permission", PERMISSIONS.USER_GROUP_DELETE));

    options.AddPolicy("user-view", policy => policy.RequireClaim("permission", PERMISSIONS.USER_VIEW));
    options.AddPolicy("user-add", policy => policy.RequireClaim("permission", PERMISSIONS.USER_ADD));
    options.AddPolicy("user-update", policy => policy.RequireClaim("permission", PERMISSIONS.USER_UPDATE));
    options.AddPolicy("user-delete", policy => policy.RequireClaim("permission", PERMISSIONS.USER_DELETE));

    options.AddPolicy("customer-view", policy => policy.RequireClaim("permission", PERMISSIONS.CUSTOMER_VIEW));
    options.AddPolicy("customer-add", policy => policy.RequireClaim("permission", PERMISSIONS.CUSTOMER_ADD));
    options.AddPolicy("customer-update", policy => policy.RequireClaim("permission", PERMISSIONS.CUSTOMER_UPDATE));
    options.AddPolicy("customer-delete", policy => policy.RequireClaim("permission", PERMISSIONS.CUSTOMER_DELETE));

    options.AddPolicy("employee-view", policy => policy.RequireClaim("permission", PERMISSIONS.EMPLOYEE_VIEW));
    options.AddPolicy("employee-add", policy => policy.RequireClaim("permission", PERMISSIONS.EMPLOYEE_ADD));
    options.AddPolicy("employee-update", policy => policy.RequireClaim("permission", PERMISSIONS.EMPLOYEE_UPDATE));
    options.AddPolicy("employee-delete", policy => policy.RequireClaim("permission", PERMISSIONS.EMPLOYEE_DELETE));

    options.AddPolicy("destination-view", policy => policy.RequireClaim("permission", PERMISSIONS.DESTINATION_VIEW));
    options.AddPolicy("destination-add", policy => policy.RequireClaim("permission", PERMISSIONS.DESTINATION_ADD));
    options.AddPolicy("destination-update", policy => policy.RequireClaim("permission", PERMISSIONS.DESTINATION_UPDATE));
    options.AddPolicy("destination-delete", policy => policy.RequireClaim("permission", PERMISSIONS.DESTINATION_DELETE));

    options.AddPolicy("tour-view", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_VIEW));
    options.AddPolicy("tour-add", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_ADD));
    options.AddPolicy("tour-update", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_UPDATE));
    options.AddPolicy("tour-delete", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_DELETE));

    options.AddPolicy("tour-destination-view", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_DESTINATION_VIEW));
    options.AddPolicy("tour-destination-add", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_DESTINATION_ADD));
    options.AddPolicy("tour-destination-update", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_DESTINATION_UPDATE));
    options.AddPolicy("tour-destination-delete", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_DESTINATION_DELETE));

    options.AddPolicy("tour-employee-view", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_EMPLOYEE_VIEW));
    options.AddPolicy("tour-employee-add", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_EMPLOYEE_ADD));
    options.AddPolicy("tour-employee-update", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_EMPLOYEE_UPDATE));
    options.AddPolicy("tour-employee-delete", policy => policy.RequireClaim("permission", PERMISSIONS.TOUR_EMPLOYEE_DELETE));

    options.AddPolicy("booking-view", policy => policy.RequireClaim("permission", PERMISSIONS.BOOKING_VIEW));
    options.AddPolicy("booking-add", policy => policy.RequireClaim("permission", PERMISSIONS.BOOKING_ADD));
    options.AddPolicy("booking-update", policy => policy.RequireClaim("permission", PERMISSIONS.BOOKING_UPDATE));
    options.AddPolicy("booking-delete", policy => policy.RequireClaim("permission", PERMISSIONS.BOOKING_DELETE));

    options.AddPolicy("payment-view", policy => policy.RequireClaim("permission", PERMISSIONS.PAYMENT_VIEW));
    options.AddPolicy("payment-add", policy => policy.RequireClaim("permission", PERMISSIONS.PAYMENT_ADD));
    options.AddPolicy("payment-update", policy => policy.RequireClaim("permission", PERMISSIONS.PAYMENT_UPDATE));
    options.AddPolicy("payment-delete", policy => policy.RequireClaim("permission", PERMISSIONS.PAYMENT_DELETE));

    options.AddPolicy("feedback-view", policy => policy.RequireClaim("permission", PERMISSIONS.FEEDBACK_VIEW));
    options.AddPolicy("feedback-add", policy => policy.RequireClaim("permission", PERMISSIONS.FEEDBACK_ADD));
    options.AddPolicy("feedback-update", policy => policy.RequireClaim("permission", PERMISSIONS.FEEDBACK_UPDATE));
    options.AddPolicy("feedback-delete", policy => policy.RequireClaim("permission", PERMISSIONS.FEEDBACK_DELETE));

    options.AddPolicy("account-view", policy => policy.RequireClaim("permission", PERMISSIONS.ACCOUNT_VIEW));
    options.AddPolicy("account-add", policy => policy.RequireClaim("permission", PERMISSIONS.ACCOUNT_ADD));
    options.AddPolicy("account-update", policy => policy.RequireClaim("permission", PERMISSIONS.ACCOUNT_UPDATE));
    options.AddPolicy("account-delete", policy => policy.RequireClaim("permission", PERMISSIONS.ACCOUNT_DELETE));

});


// Thêm logging vào console
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

// Cấu hình các dịch vụ HTTP request pipeline.
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


app.Use(async (context, next) =>
{
    if (context.User.Identity.IsAuthenticated)
    {
        var userManager = context.RequestServices.GetRequiredService<UserManager<Account>>();
        var user = await userManager.GetUserAsync(context.User);

        if (user != null)
        {
            context.Items["UserName"] = user.UserName;
        }
    }

    await next.Invoke();
});

// Lấy dịch vụ Scoped và chạy SeedRolesAsync trong phạm vi hợp lệ
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    var roleSeed = services.GetRequiredService<RoleSeed>();
    await roleSeed.SeedRolesAsync();  // Seed roles

    // Tiếp theo, khởi tạo SeedData cho người dùng
    var userManager = services.GetRequiredService<UserManager<Account>>();
    await AccountAdminSeed.Initialize(services, userManager);

    
    DestinationSeed.SeedDestinationsAsync(context).Wait();

    TourSeed.SeedToursAsync(context).Wait();
}



app.Run();
