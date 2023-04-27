using Microsoft.EntityFrameworkCore;
using NkFincorpWebApp.BAL;
using NkFincorpWebApp.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<NkFincorpMvcprojectContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DemoCS")
    ));




builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();




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
    pattern: "{controller=Customers}/{action=Index}/{id?}");

app.Run();
