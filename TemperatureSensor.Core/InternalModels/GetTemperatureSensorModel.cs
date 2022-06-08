namespace TemperatureSensor.Core.InternalModels
{
    public record GetTemperatureSensorModel
    {
        public string SensorId { get; set; } = string.Empty;
    }
}
