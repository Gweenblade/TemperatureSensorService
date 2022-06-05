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
                // Use a Scoped container to create jobs. I'll touch on this later
                q.UseMicrosoftDependencyInjectionJobFactory();

                // Create a "key" for the job
                var jobKey = new JobKey("TemperatureNotificationJob");

                // Register the job with the DI container
                q.AddJob<TemperatureNotificationJob>(opts => opts.WithIdentity(jobKey));

                // Create a trigger for the job
                q.AddTrigger(opts => opts
                    .ForJob(jobKey) // link to the HelloWorldJob
                    .WithIdentity("TemperatureNotificationJob-trigger") // give the trigger a unique name
                    .WithCronSchedule("0 * * ? * *")); // run every 5 seconds
            });

            services.AddQuartzHostedService(
                q => q.WaitForJobsToComplete = true);
        }
    }
}
