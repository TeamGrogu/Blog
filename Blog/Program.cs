<<<<<<< HEAD
using Blog.Services;
=======
using Blog.DAL;
using Microsoft.EntityFrameworkCore;
>>>>>>> 80bae1923f38a7b93b318acf7513cda3688a446a

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
<<<<<<< HEAD
builder.Services.ConfigureApplicationCookie(
                 option =>
                 {
                     option.Cookie.Name = "UserCookie";
                     option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                     option.SlidingExpiration = true;
                 }
             );
builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddSingleton(builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
builder.Services.AddScoped<IEmailService, EmailService>();
=======
builder.Services.AddDbContext<Context>
    (x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

>>>>>>> 80bae1923f38a7b93b318acf7513cda3688a446a
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
