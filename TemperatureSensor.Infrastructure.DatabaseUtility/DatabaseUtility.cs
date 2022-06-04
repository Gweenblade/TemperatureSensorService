using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Infrastructure.DatabaseUtility.DbContexts;
using TemperatureSensor.Infrastructure.DatabaseUtility.Service;

namespace TemperatureSensor.Infrastructure.DatabaseUtility
{
    public class DatabaseUtility
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ITemperatureSensorRepository, TemperatureSensorRepository>();
            services.AddDbContext<TemperatureSensorContext>(options => options.UseSqlServer(connectionString));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
