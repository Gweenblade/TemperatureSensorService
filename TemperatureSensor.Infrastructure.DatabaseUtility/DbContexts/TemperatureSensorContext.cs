using Microsoft.EntityFrameworkCore;
using TemperatureSensor.Infrastructure.DatabaseUtility.Entities;

namespace TemperatureSensor.Infrastructure.DatabaseUtility.DbContexts
{
    public class TemperatureSensorContext : DbContext
    {
        public DbSet<TemperatureSensorEntity> TemperatureSensors { get; set; };
    }
}
