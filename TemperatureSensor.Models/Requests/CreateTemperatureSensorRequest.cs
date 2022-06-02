namespace TemperatureSensor.Models.Requests
{
    public record CreateTemperatureSensorRequest
    {
        public string SensorName { get; set; }
        public int Depth { get; set; }
        public int CircleOfLatitude { get; set; }
        public int Meridian { get; set; }
    }
}
