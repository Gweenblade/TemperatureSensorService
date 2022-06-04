using Microsoft.EntityFrameworkCore;
using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Core.InternalModels;
using TemperatureSensor.Infrastructure.DatabaseUtility.DbContexts;

namespace TemperatureSensor.Infrastructure.DatabaseUtility.Service
{
    internal class TemperatureSensorRepository : ITemperatureSensorRepository
    {
        private readonly TemperatureSensorContext _context;
        public TemperatureSensorRepository(TemperatureSensorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<bool> CreateTemperatureSensorAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TemperatureSensorDto> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel)
        {
            var x = 
                (await _context.TemperatureSensors.Where(x => x.SensorId == getTemperatureSensorModel.SensorId).ToListAsync()).FirstOrDefault();
            
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TemperatureSensorDto>> GetTemperatureSensorsAsync(GetTemperatureSensorModel getTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveDatabaseEntryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTemperatureSensorAsync()
        {
            throw new NotImplementedException();
        }
    }
}
