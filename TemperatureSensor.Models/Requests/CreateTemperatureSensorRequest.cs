using Microsoft.AspNetCore.Mvc;

namespace TemperatureSensor.Models.Requests
{
    public record CreateTemperatureSensorRequest
    {
        [FromRoute]
        public string SensorId { get; set; }

        [FromQuery]
        public int Depth { get; set; }

        [FromQuery]
        public int CircleOfLatitude { get; set; }

        [FromQuery]
        public int Meridian { get; set; }
    }
}
