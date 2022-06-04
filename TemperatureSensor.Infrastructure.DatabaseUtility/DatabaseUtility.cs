using Microsoft.Extensions.DependencyInjection;
using TemperatureSensor.Infrastructure.DatabaseUtility.DbContexts;

namespace TemperatureSensor.Infrastructure.DatabaseUtility
{
    public class DatabaseUtility
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TemperatureSensorContext>();
        }
    }
}
