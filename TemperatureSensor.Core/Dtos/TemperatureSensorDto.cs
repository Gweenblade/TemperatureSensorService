namespace TemperatureSensor.Core.Dtos
{
    public class TemperatureSensorDto
    {
        public int Id { get; set; }
        public string SensorId { get; set; }

        public int Depth { get; set; }

        public int CircleOfLatitude { get; set; }

        public int Meridian { get; set; }
        public int Temperature { get; set; }
    }
}
