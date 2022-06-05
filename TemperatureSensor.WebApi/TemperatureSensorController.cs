using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Core.InternalModels;
using TemperatureSensor.Models.Requests;

namespace TemperatureSensor.Infrastructure.WebApi
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
        public async Task<IActionResult> CreateTemperatureSensorAsync(
            [FromRoute] CreateTemperatureSensorRequest createTemperatureSensorRequest)
        {

            var isSuccess = await _temperatureSensorService.CreateTemperatureSensorAsync(
                _mapper.Map<CreateTemperatureSensorModel>(createTemperatureSensorRequest));
            if (isSuccess)
            {
                return Ok();
            }
            else
            {
                return Conflict();
            }

        }

        [HttpPatch("")]
        public async Task<IActionResult> UpdateTemperatureSensorAsync(
            [FromRoute] UpdateTemperatureSensorRequest updateTemperatureSensorRequest)
        {
            var isSuccess = await _temperatureSensorService.UpdateTemperatureSensorAsync(
                _mapper.Map<UpdateTemperatureSensorModel>(updateTemperatureSensorRequest));
            if (isSuccess)
            {
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveTemperatureSensorAsync(
            [FromRoute] RemoveTemperatureSensorRequest removeTemperatureSensorRequest)
        {
            await _temperatureSensorService.RemoveTemperatureSensorAsync(
                    _mapper.Map<RemoveTemperatureSensorModel>(removeTemperatureSensorRequest));
            return NoContent();
        }

        [HttpGet("{SensorId}")]
        public async Task<IActionResult> GetTemperatureSensorAsync(
            [FromRoute] GetTemperatureSensorRequest getTemperatureSensorRequest)
        {
            var sensor = await _temperatureSensorService.GetTemperatureSensorAsync(
                _mapper.Map<GetTemperatureSensorModel>(getTemperatureSensorRequest));
            if (sensor != null)
            {
                return Ok(sensor);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTemperatureSensorsAsync(
            [FromRoute] GetTemperatureSensorsRequest getTemperatureSensorsRequest)
        {

            var sensors = await _temperatureSensorService.GetTemperatureSensorsAsync(
                _mapper.Map<GetTemperatureSensorsModel>(getTemperatureSensorsRequest));
            return Ok(sensors);
        }
    }
}