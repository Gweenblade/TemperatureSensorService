using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureSensor.Infrastructure.DatabaseUtility.Entities
{
    public class TemperatureSensorEntity
    {
        public TemperatureSensorEntity(string sensorId)
        {
            SensorId = sensorId;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SensorId { get; set; }
        public int Depth { get; set; }
        public int CircleOfLatitude { get; set; }
        public int Meridian { get; set; }
        public int Temperature { get; set; }
    }
}
