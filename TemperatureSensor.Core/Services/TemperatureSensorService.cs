using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Core.Interfaces;
using TemperatureSensor.Core.InternalModels;

namespace TemperatureSensor.Core.Services
{
    internal class TemperatureSensorService : ITemperatureSensorService
    {
        private readonly ITemperatureSensorRepository _temperatureSensorRepository;
        private readonly ITemperatureGeneratorService _temperatureGeneratorService;
        public TemperatureSensorService(ITemperatureSensorRepository temperatureSensorRepository, ITemperatureGeneratorService temperatureGeneratorService)
        {
            _temperatureSensorRepository = temperatureSensorRepository ?? throw new ArgumentNullException(nameof(temperatureSensorRepository));
            _temperatureGeneratorService = temperatureGeneratorService ?? throw new ArgumentNullException(nameof(temperatureGeneratorService));
        }
        public async Task<bool> CreateTemperatureSensorAsync(CreateTemperatureSensorModel createTemperatureSensorModel)
        {
            createTemperatureSensorModel.Temperature = _temperatureGeneratorService.GenerateTemperature();
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
            updateTemperatureSensorModel.Temperature = _temperatureGeneratorService.GenerateTemperature();
            return await _temperatureSensorRepository.UpdateTemperatureSensorAsync(updateTemperatureSensorModel);
        }
    }
}
