using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Core.InternalModels;

namespace TemperatureSensor.Core.Services
{
    internal class TemperatureSensorService : ITemperatureSensorService
    {
        private readonly ITemperatureSensorRepository _temperatureSensorRepository;
        public TemperatureSensorService(ITemperatureSensorRepository temperatureSensorRepository)
        {
            _temperatureSensorRepository = temperatureSensorRepository ?? throw new ArgumentNullException(nameof(temperatureSensorRepository));
        }
        public async Task<bool> CreateTemperatureSensorAsync(CreateTemperatureSensorModel createTemperatureSensorModel)
        {
            return await _temperatureSensorRepository.CreateTemperatureSensorAsync(createTemperatureSensorModel);
        }

        public async Task<TemperatureSensorDto> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel)
        {
            return await _temperatureSensorRepository.GetTemperatureSensorAsync(getTemperatureSensorModel);
        }

        public async Task<IEnumerable<TemperatureSensorDto>> GetTemperatureSensorsAsync(GetTemperatureSensorsModel getTemperatureSensorsModel)
        {
            return await _temperatureSensorRepository.GetTemperatureSensorsAsync(getTemperatureSensorsModel);
        }

        public async Task RemoveTemperatureSensorAsync(RemoveTemperatureSensorModel removeTemperatureSensorModel)
        {
            await _temperatureSensorRepository.RemoveTemperatureSensor(removeTemperatureSensorModel);
        }

        public async Task<bool> UpdateTemperatureSensorAsync(UpdateTemperatureSensorModel updateTemperatureSensorModel)
        {
            return await _temperatureSensorRepository.UpdateTemperatureSensorAsync(updateTemperatureSensorModel);
        }
    }
}
