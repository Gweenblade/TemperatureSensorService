using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.InternalModels;

namespace TemperatureSensor.Core.Infrastructure
{
    public interface ITemperatureSensorRepository
    {
        Task<bool> CreateTemperatureSensorAsync(CreateTemperatureSensorModel createTemperatureSensorModel);
        Task<bool> UpdateTemperatureSensorAsync(UpdateTemperatureSensorModel updateTemperatureSensorModel);
        Task<TemperatureSensorDto> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel);
        Task<IEnumerable<TemperatureSensorDto>> GetTemperatureSensorsAsync(GetTemperatureSensorsModel getTemperatureSensorModel);
        Task RemoveTemperatureSensor (RemoveTemperatureSensorModel removeTemperatureSensorModel);
    }
}
