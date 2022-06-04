using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TemperatureSensor.Infrastructure.WebApi
{
    public class WebApi
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
