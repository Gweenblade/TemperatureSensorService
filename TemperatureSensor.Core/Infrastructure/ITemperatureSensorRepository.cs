using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.InternalModels;

namespace TemperatureSensor.Core.Infrastructure
{
    public interface ITemperatureSensorRepository
    {
        Task<bool> CreateTemperatureSensorAsync();
        Task<bool> UpdateTemperatureSensorAsync();
        Task<TemperatureSensorDto> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel);
        Task<IEnumerable<TemperatureSensorDto>> GetTemperatureSensorsAsync(GetTemperatureSensorModel getTemperatureSensorModel);
        Task<bool> RemoveDatabaseEntryAsync();
    }
}
