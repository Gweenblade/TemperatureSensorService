namespace TemperatureSensor.Models.Responses
{
    public record GetTemperatureSensorResponse
    {
        public int Id { get; set; }
        public string SensorId { get; set; }
        public int Depth { get; set; }
        public int CircleOfLatitude { get; set; }
        public int Meridian { get; set; }
        public double Temperature { get; set; }
    }
}
