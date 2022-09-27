using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yang.Weather.Business.Services;
using Yang.Weather.Business.Models;
using Yang.Weather.DataAccess.Contracts;
using Yang.Weather.DataAccess.Dao;
using Yang.Weather.DataAccess.Config;
using Yang.Weather.Core.WebApp.Config;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddDbContext<WeatherContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherContext") ?? throw new InvalidOperationException("Connection string 'WeatherContext' not found.")));

//Register interfaces for DI used in controller or Razor page
builder.Services.AddSingleton<IGoogleMapApiService, GoogleMapApiService>();
builder.Services.AddSingleton<IWeatherApiService, WeatherApiService>();
builder.Services.AddSingleton<IDataStoreConfigurationProvider, AppConfigurationProvider>();
builder.Services.AddSingleton<IWeatherDao, WeatherDao>();
builder.Services.AddSingleton<IGeoCodeDao,GeoCodeDao >();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
