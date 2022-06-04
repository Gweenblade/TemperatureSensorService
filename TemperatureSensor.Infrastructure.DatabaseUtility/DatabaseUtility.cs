﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TemperatureSensor.Infrastructure.DatabaseUtility.DbContexts;

namespace TemperatureSensor.Infrastructure.DatabaseUtility
{
    public class DatabaseUtility
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TemperatureSensorContext>(options => options.UseSqlServer(connectionString));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}