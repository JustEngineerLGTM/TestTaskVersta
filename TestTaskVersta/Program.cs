using Microsoft.EntityFrameworkCore;
using TestTaskVersta.Middleware;
using TestTaskVersta.Models;
using TestTaskVersta.Repositories;
using TestTaskVersta.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Order Services
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Service and reconnect for Postgres
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        o => o.EnableRetryOnFailure(
            10,
            TimeSpan.FromSeconds(5),
            null
        )
    ));

var app = builder.Build();

// Migration
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();
app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=List}/{id?}");

app.Run();