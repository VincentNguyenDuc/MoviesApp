using MovieApp.Data;
using MovieApp.Services.Actors;
using MovieApp.Services.Cinemas;
using MovieApp.Services.Movies;
using MovieApp.Services.Producers;


using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<ICinemasService, CinemasService>();
builder.Services.AddScoped<IProducersService, ProducersService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();

// Database configuration
// builder.Services.AddDbContext<AppDbContext>(options => options
//         .UseSqlite(builder
//         .Configuration
//         .GetConnectionString("SqliteConnectionString")));

builder.Services.AddDbContext<AppDbContext>(options => options
        .UseSqlServer(builder
        .Configuration
        .GetConnectionString("SqlServerConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.CreateDbIfNotExists();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();
