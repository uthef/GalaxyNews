using GalaxyNews.Database.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GalaxyNewsContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("GalaxyNews"))
);
builder.Services.AddScoped<GalaxyNewsContext>();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();
