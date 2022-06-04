using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TemperatureSensor.Models.Requests;

namespace TemperatureSensor.WebApi
{
    [ApiController]
    [Route("TemperatureSensors")]
    public class TemperatureSensorController : ControllerBase
    {
        private readonly IMapper _mapper;

        public TemperatureSensorController(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
         
        [HttpPost("{SensorId}")]
        public async Task<IActionResult> CreateTemperatureSensorAsync([FromRoute] CreateTemperatureSensorRequest createTemperatureSensorRequest)
        {
            throw new NotImplementedException();
        }
        
        [HttpPatch("{SensorId}")]
        public async Task<IActionResult> UpdateTemperatureSensorAsync([FromRoute] UpdateTemperatureSensorRequest updateTemperatureSensorRequest)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{SensorId}")]
        public async Task<IActionResult> RemoveTemperatureSensorAsync([FromRoute] RemoveTemperatureSensorRequest removeTemperatureSensorRequest)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{SensorId}")]
        public async Task<IActionResult> GetTemperatureSensorAsync([FromRoute] GetTemperatureSensorRequest getTemperatureSensorRequest)
        {
            throw new NotImplementedException();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTemperatureSensorsAsync([FromRoute] GetTemperatureSensorsRequest getTemperatureSensorsRequest)
        {
            throw new NotImplementedException();
        }
    }
}