using Microsoft.EntityFrameworkCore;
using RentCarApi.Persistence.Context;
using RentCarApi.Persistence.Repositories.UnitOfWork;
using RentCarApi.Persistence.Repositories.Vehicles.Base;
using RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.Location;
using RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.VehicleMark;
using RentCarApi.Persistence.Repositories.Vehicles.TechnicalInformation.VehicleModel;
using RentCarApi.Services.VehicleServices.VehicleService;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.LocationService;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.MarkService;
using RentCarApi.Services.VehicleServices.VehiclesTechnicalServices.ModelService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentCarConnection"));
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IMarkRepository, MarkRepository>();
builder.Services.AddTransient<IModelRepository, ModelRepository>();
builder.Services.AddTransient<IVehicleLocationRepository, VehicleLocationRepository>();

builder.Services.AddScoped<ModelService>();
builder.Services.AddScoped<MarkServices>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<VehiclesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
