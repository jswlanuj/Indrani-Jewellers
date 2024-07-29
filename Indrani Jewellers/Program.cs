using Indrani_Jewellers.Data;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("QAConnection")));

// Add session management
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".Indrani_Jewellers.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

// Add authentication (example with cookies)
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.Cookie.Name = ".Indrani_Jewellers.Cookie";
    options.LoginPath = "/Account/Login"; // Customize login path if needed
    options.AccessDeniedPath = "/Account/AccessDenied"; // Customize access denied path if needed
});

// Add authorization
builder.Services.AddAuthorization();

// Add scoped services
builder.Services.AddScoped<EmployeeServices>();
builder.Services.AddScoped<ProductDetailServices>();
builder.Services.AddScoped<ProductSeriveces>();
builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<LoanService>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // Use session middleware
app.UseAuthentication(); // Use authentication middleware
app.UseAuthorization(); // Use authorization middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LandingPage}/{action=Index}/{id?}");

app.Run();
