using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Core.InternalModels;

namespace TemperatureSensor.Core.Services
{
    internal class TemperatureSensorService : ITemperatureSensorService
    {
        private readonly ITemperatureSensorRepository _repository;
        public TemperatureSensorService(ITemperatureSensorRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public Task<bool> CreateTemperatureSensorAsync(CreateTemperatureSensorModel createTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TemperatureSensorDto>> GetTemperatureSensorsAsync(GetTemperatureSensorModel getTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveTemperatureSensorAsync(RemoveTemperatureSensorModel removeTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTemperatureSensorAsync(UpdateTemperatureSensorModel updateTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }

        Task<TemperatureSensorDto> ITemperatureSensorService.GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }
    }
}
