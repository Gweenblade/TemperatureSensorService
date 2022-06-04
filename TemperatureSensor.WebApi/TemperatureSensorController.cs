using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Models.Requests;

namespace TemperatureSensor.WebApi
{
    [ApiController]
    [Route("TemperatureSensors")]
    public class TemperatureSensorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITemperatureSensorService _temperatureSensorService;

        public TemperatureSensorController(IMapper mapper, ITemperatureSensorService temperatureSensorService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _temperatureSensorService = temperatureSensorService ??
                                        throw new ArgumentNullException(nameof(temperatureSensorService));
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