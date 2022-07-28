using Agency.Core;
using Agency.Core.Contracts;
using Agency.Core.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IEngine, Engine>();
builder.Services.AddSingleton<IWriter, ConsoleWriter>();
builder.Services.AddSingleton<IReader, ConsoleReader>();
builder.Services.AddSingleton<IParser, CommandParser>();
builder.Services.AddSingleton<IAgencyDatabase, AgencyDatabase>();
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
