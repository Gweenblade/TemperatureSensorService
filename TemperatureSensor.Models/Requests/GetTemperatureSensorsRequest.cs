using Microsoft.AspNetCore.Mvc;

namespace TemperatureSensor.Models.Requests
{
    public record GetTemperatureSensorsRequest
    {
        [FromQuery]
        public int Meridian { get; set; }
    }
}
