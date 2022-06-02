using TemperatureSensor.Models.InternalModels;

namespace TemperatureSensor.Models.Requests
{
    public record GetTemperatureSensorsRequest
    {
        public Hemisphere? Hemisphere { get; set; } = null;
    }
}
