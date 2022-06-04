using Microsoft.AspNetCore.Mvc;
using TemperatureSensor.Models.ServiceModels;

namespace TemperatureSensor.Models.Requests
{
    public record GetTemperatureSensorsRequest
    {
        [FromQuery]
        public Hemisphere? Hemisphere { get; set; } = null;
    }
}
