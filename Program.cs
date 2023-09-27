using Microsoft.EntityFrameworkCore;
using RentCarApi.Context;
using RentCarApi.Repositories.UnitOfWork;
using RentCarApi.Repositories.Vehicles.Base;
using RentCarApi.Repositories.Vehicles.TechnicalInformation.Location;
using RentCarApi.Repositories.Vehicles.TechnicalInformation.VehicleMark;
using RentCarApi.Repositories.Vehicles.TechnicalInformation.VehicleModel;

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

builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IMarkRepository, MarkRepository>();
builder.Services.AddTransient<IModelRepository, ModelRepository>();
builder.Services.AddTransient<IVehicleLocationRepository, VehicleLocationRepository>();

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
