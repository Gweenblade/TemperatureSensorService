using Microsoft.Extensions.DependencyInjection;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Core.Interfaces;
using TemperatureSensor.Core.Services;

namespace TemperatureSensor.Core
{
    public class Core
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITemperatureNotificationService, TemperatureNotificationService>();
            services.AddScoped<ITemperatureSensorService, TemperatureSensorService>();
        }
    }
}
