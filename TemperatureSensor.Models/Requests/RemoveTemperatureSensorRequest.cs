using Microsoft.AspNetCore.Mvc;

namespace TemperatureSensor.Models.Requests
{
    public record RemoveTemperatureSensorRequest
    {
        [FromRoute]
        public string SensorId { get; set; } = string.Empty;
    }
}
