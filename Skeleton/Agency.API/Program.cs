using Agency.Core;
using Agency.Core.Contracts;
using Agency.Models;
using Agency.Models.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IAgencyDatabase, AgencyDatabase>();
builder.Services.AddSingleton<ITruckService, TruckService>();
builder.Services.AddSingleton<IBusService, BusService>();
builder.Services.AddSingleton<ITrainService, TrainService>();
builder.Services.AddSingleton<IVehicleService, VehicleService>();
builder.Services.AddSingleton<IAirplaneService, AirplaneService>();
builder.Services.AddSingleton<ICargoShipService, CargoShipService>();
builder.Services.AddSingleton<IJourneyService, JourneyService>();
builder.Services.AddSingleton<ITicketService, TicketService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
