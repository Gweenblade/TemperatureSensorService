namespace TemperatureSensor.Models.Requests
{
    public record GetTemperatureSensorRequest
    {
        public string SensorName { get; set; }
    }
}
