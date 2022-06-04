using TemperatureSensor.Core;
using TemperatureSensor.Infrastructure.DatabaseUtility;
using TemperatureSensor.Infrastructure.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.EnableEndpointRouting = false);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

WebApi.ConfigureServices(builder.Services);
Core.ConfigureServices(builder.Services);
DatabaseUtility.ConfigureServices(builder.Services, builder.Configuration["ConnectionStrings:DbConnectionString"]);

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


