using TemperatureSensor.Core;
using TemperatureSensor.Infrastructure.DatabaseUtility;
using TemperatureSensor.Infrastructure.WebApi;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options => options.EnableEndpointRouting = false);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

WebApi.ConfigureServices(builder.Services);
DatabaseUtility.ConfigureServices(builder.Services, builder.Configuration["ConnectionStrings:DbConnectionString"]);
Core.ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


