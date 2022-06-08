using Microsoft.AspNetCore.Mvc;

namespace TemperatureSensor.Models.Requests
{
    public record GetTemperatureSensorRequest
    {
        [FromRoute]
        public string SensorId { get; set; } = string.Empty;
    }
}
