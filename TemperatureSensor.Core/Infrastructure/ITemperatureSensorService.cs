using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.InternalModels;

namespace TemperatureSensor.Core.Infrastructure
{
    public interface ITemperatureSensorService
    {
        Task<TemperatureSensorDto> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel);
        Task<IEnumerable<TemperatureSensorDto>> GetTemperatureSensorsAsync(GetTemperatureSensorModel getTemperatureSensorModel);
        Task<bool> CreateTemperatureSensorAsync(CreateTemperatureSensorModel createTemperatureSensorModel);
        Task<bool> UpdateTemperatureSensorAsync(UpdateTemperatureSensorModel updateTemperatureSensorModel);
        Task RemoveTemperatureSensorAsync(RemoveTemperatureSensorModel removeTemperatureSensorModel);
    }
}
