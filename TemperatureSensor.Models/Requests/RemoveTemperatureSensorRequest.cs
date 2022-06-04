using Microsoft.AspNetCore.Mvc;

namespace TemperatureSensor.Models.Requests
{
    public record RemoveTemperatureSensorRequest
    {
        [FromRoute]
        public int Id { get; set; }
    }
}
