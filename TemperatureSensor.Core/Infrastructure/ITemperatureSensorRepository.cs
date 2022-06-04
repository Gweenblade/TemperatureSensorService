using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.InternalModels;

namespace TemperatureSensor.Core.Infrastructure
{
    public interface ITemperatureSensorRepository
    {
        void CreateTemperatureSensorAsync(CreateTemperatureSensorModel createTemperatureSensorModel);
        void UpdateTemperatureSensorAsync(UpdateTemperatureSensorModel updateTemperatureSensorModel);
        Task<TemperatureSensorDto> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel);
        Task<IEnumerable<TemperatureSensorDto>> GetTemperatureSensorsAsync(GetTemperatureSensorsModel getTemperatureSensorModel);
        Task RemoveTemperatureSensor (RemoveTemperatureSensorModel removeTemperatureSensorModel);
    }
}
