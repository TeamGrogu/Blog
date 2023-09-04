using Blog.Services;
using Blog.Models.DAL;
using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Blog.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Blog.Models.ViewModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<MakaleVM>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>
	(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

builder.Services.AddIdentity<User, Role>
	(x =>
	{
		x.SignIn.RequireConfirmedEmail = true;
		x.Password.RequiredLength = 6;
	}).AddRoles<Role>().AddEntityFrameworkStores<Context>()
	  .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(
                 option =>
                 {
                     option.Cookie.Name = "UserCookie";
                     option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                     option.SlidingExpiration = true;
                 }
             );
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton(builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
builder.Services.AddScoped<IEmailService, EmailService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
