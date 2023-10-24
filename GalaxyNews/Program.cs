using GalaxyNews.Database.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// !!! galaxynews_cs environment variable is required in order to connect to the database
builder.Services.AddDbContext<GalaxyNewsContext>();
builder.Services.AddScoped<GalaxyNewsContext>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.Run();
