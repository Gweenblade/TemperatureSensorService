using Microsoft.AspNetCore.Mvc;

namespace TemperatureSensor.Models.Requests
{
    public record UpdateTemperatureSensorRequest
    {
        [FromQuery]
        public string SensorId { get; set; } = string.Empty;

        [FromQuery]
        public int Depth { get; set; }

        [FromQuery]
        public int CircleOfLatitude { get; set; }

        [FromQuery]
        public int Meridian { get; set; }
    }
}
