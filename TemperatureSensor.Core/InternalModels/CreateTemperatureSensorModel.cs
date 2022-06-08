namespace TemperatureSensor.Core.InternalModels
{
    public record CreateTemperatureSensorModel
    {
        public string SensorId { get; set; } = string.Empty;
        public int Depth { get; set; }
        public int CircleOfLatitude { get; set; }
        public int Meridian { get; set; }
        public int Temperature { get; set; }
    }
}
