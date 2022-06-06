using Microsoft.Extensions.DependencyInjection;
using Quartz;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Core.Interfaces;
using TemperatureSensor.Core.Jobs;
using TemperatureSensor.Core.Services;

namespace TemperatureSensor.Core
{
    public class Core
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITemperatureNotificationJob, TemperatureNotificationJob>();
            services.AddScoped<ITemperatureSensorService, TemperatureSensorService>();
            services.AddSingleton<ITemperatureGeneratorService, TemperatureGeneratorService>();
            services.AddQuartz(options => options.UseMicrosoftDependencyInjectionJobFactory());

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();

                var jobKey = new JobKey("TemperatureNotificationJob");

                q.AddJob<TemperatureNotificationJob>(opts => opts.WithIdentity(jobKey));

                q.AddTrigger(opts => opts
                    .ForJob(jobKey) 
                    .WithIdentity("TemperatureNotificationJob-trigger") 
                    .WithCronSchedule("0/30 * * ? * *")); 
            });

            services.AddQuartzHostedService(
                q => q.WaitForJobsToComplete = true);
        }
    }
}
