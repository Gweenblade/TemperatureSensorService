using Microsoft.AspNetCore.Mvc;

namespace TemperatureSensor.WebApi
{
    [ApiController]
    [Route("TemperatureSensors")]
    public class TemperatureSensorController : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> CreateTemperatureSensorAsync()
        {
            throw new NotImplementedException();
        }
        
        [HttpPatch("")]
        public async Task<IActionResult> UpdateTemperatureSensorAsync()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("")]
        public async Task<IActionResult> RemoveTemperatureSensorAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTemperatureSensorAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("1")]
        public async Task<IActionResult> GetTemperatureSensorsAsync()
        {
            throw new NotImplementedException();
        }
    }
}