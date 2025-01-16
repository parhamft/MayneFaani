using AppService.App.Cars;
using AppService.App.Requests;
using AppService.App.UserCars;
using AppService.App.Users;
using Domain.Core.App.Cars.AppServices;
using Domain.Core.App.Cars.Data;
using Domain.Core.App.Cars.Services;
using Domain.Core.App.RequestLogs.Data;
using Domain.Core.App.RequestLogs.Services;
using Domain.Core.App.Requests.AppServices;
using Domain.Core.App.Requests.Data;
using Domain.Core.App.Requests.Services;
using Domain.Core.App.UserCars.AppServices;
using Domain.Core.App.UserCars.Data;
using Domain.Core.App.UserCars.Services;
using Domain.Core.App.Users.AppServices;
using Domain.Core.App.Users.Data;
using Domain.Core.App.Users.Services;
using Infra.DataBase;
using Infra.repo.App.Cars;
using Infra.repo.App.RequestLogs;
using Infra.repo.App.Requests;
using Infra.repo.App.UserCars;
using Infra.repo.App.Users;
using Microsoft.EntityFrameworkCore;
using Service.App.Cars;
using Service.App.RequestLogs;
using Service.App.Requests;
using Service.App.UserCars;
using Service.App.Users;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//var ConnectionString = builder.Configuration.GetConnectionString("AppDB");
builder.Services.AddDbContext<AppDBContext>();

builder.Services.AddScoped<ICarRepository, CarRepositor>();
builder.Services.AddScoped<IRequestLogsRepository,RequestLogsRepository>();
builder.Services.AddScoped<IRequestRepository,RequestRepository>();
builder.Services.AddScoped<IUserCarRepository,UserCarRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserCarService,UserCarService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IRequestLogService, RequestLogService>();
builder.Services.AddScoped<IUserAppService,UserAppService>();
builder.Services.AddScoped<IUserCarAppService,UserCarAppService>();
builder.Services.AddScoped<IRequestAppService,RequestAppService>();
builder.Services.AddScoped<ICarAppService, CarAppService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
