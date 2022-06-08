using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureSensor.Infrastructure.DatabaseUtility.Entities
{
    public record TemperatureSensorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SensorId { get; set; } = string.Empty;
        public int Depth { get; set; }
        public int CircleOfLatitude { get; set; }
        public int Meridian { get; set; }
        public int Temperature { get; set; }
    }
}
