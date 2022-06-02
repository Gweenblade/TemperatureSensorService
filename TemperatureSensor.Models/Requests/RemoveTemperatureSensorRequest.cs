namespace TemperatureSensor.Models.Requests
{
    public record RemoveTemperatureSensorRequest
    {
        public string SensorName { get; set; }
    }
}
