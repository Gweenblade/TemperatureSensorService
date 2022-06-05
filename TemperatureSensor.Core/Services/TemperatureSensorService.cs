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

        public Task<TemperatureSensorDto> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TemperatureSensorDto>> GetTemperatureSensorsAsync(GetTemperatureSensorModel getTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }

        public void RemoveTemperatureSensorAsync(RemoveTemperatureSensorModel removeTemperatureSensorModel)
        {
            _temperatureSensorRepository.RemoveTemperatureSensor(removeTemperatureSensorModel);
        }

        public void UpdateTemperatureSensorAsync(UpdateTemperatureSensorModel updateTemperatureSensorModel)
        {
            _temperatureSensorRepository.UpdateTemperatureSensorAsync(updateTemperatureSensorModel);
        }
    }
}
