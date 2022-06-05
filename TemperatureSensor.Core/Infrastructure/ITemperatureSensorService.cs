using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.InternalModels;

namespace TemperatureSensor.Core.Infrastructure
{
    public interface ITemperatureSensorService
    {
        Task<TemperatureSensorDto> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel);
        Task<IEnumerable<TemperatureSensorDto>> GetTemperatureSensorsAsync(GetTemperatureSensorModel getTemperatureSensorModel);
        Task<bool> CreateTemperatureSensorAsync(CreateTemperatureSensorModel createTemperatureSensorModel);
        void UpdateTemperatureSensorAsync(UpdateTemperatureSensorModel updateTemperatureSensorModel);
        void RemoveTemperatureSensorAsync(RemoveTemperatureSensorModel removeTemperatureSensorModel);
    }
}
