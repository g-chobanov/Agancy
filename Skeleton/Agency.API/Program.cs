using Agency.Core;
using Agency.Core.Contracts;
using Agency.Models;
using Agency.Models.Contracts;
using Agency.Models.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AgencyDatabaseContext>(options =>
    options.UseSqlServer("Data Source=DESKTOP-OHA5UQF\\SQLEXPRESS; Initial Catalog=AgencyDatabase; Integrated Security=True;"));
builder.Services.AddScoped<ITruckService, TruckService>();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<ITrainService, TrainService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IAirplaneService, AirplaneService>();
builder.Services.AddScoped<ICargoShipService, CargoShipService>();
builder.Services.AddScoped<IJourneyService, JourneyService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("corsapp");

app.Run();
