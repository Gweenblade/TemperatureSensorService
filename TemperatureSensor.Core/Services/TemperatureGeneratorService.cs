using TemperatureSensor.Core.Interfaces;

namespace TemperatureSensor.Core.Services
{
    internal class TemperatureGeneratorService : ITemperatureGeneratorService
    {
        private readonly Random _random;
        public TemperatureGeneratorService()
        {
            _random ??= new Random();
        }

        public int GenerateTemperature()
        {
            return _random.Next(-273, 10000);
        }
    }
}
