using Application.PermissionRequirement;
using Application.Services;
using Application.Services_Interface;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Seed;
using Infrastructure.Repositories;
using Infrastructure.Static;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
    var permissions = new[]
    {
        PERMISSIONS.USER_GROUP_VIEW, 
        PERMISSIONS.USER_GROUP_ADD,
        PERMISSIONS.USER_GROUP_UPDATE,
        PERMISSIONS.USER_GROUP_DELETE,

        PERMISSIONS.ACCOUNT_VIEW, 
        PERMISSIONS.ACCOUNT_ADD, 
        PERMISSIONS.ACCOUNT_UPDATE, 
        PERMISSIONS.ACCOUNT_DELETE,

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
        PERMISSIONS.ACCOUNT_BLOCK,

        PERMISSIONS.ROLE_Claim_ADD,
        PERMISSIONS.ROLE_Claim_UPDATE,
        PERMISSIONS.ROLE_Claim_DELETE,
        PERMISSIONS.ROLE_Claim_VIEW,
    };

    foreach (var permission in permissions)
    {
        options.AddPolicy(permission, policy =>
            policy.Requirements.Add(new PermissionRequirement(permission)));
    }

    options.AddPolicy("RequiredAdminOrManager", policy => policy.RequireRole("Admin","Manager"));
});
builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();


// Thêm logging vào console
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();
//app.UseMiddleware<ClaimMiddleware>();

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
