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
        public async Task<IActionResult> CreateTemperatureSensorAsync([FromRoute] CreateTemperatureSensorRequest createTemperatureSensorRequest)
        {
            try
            {
                _temperatureSensorService.CreateTemperatureSensorAsync(
                    _mapper.Map<CreateTemperatureSensorModel>(createTemperatureSensorRequest));
                if (response)
                {
                    return Ok();
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPatch("{SensorId}")]
        public async Task<IActionResult> UpdateTemperatureSensorAsync([FromRoute] UpdateTemperatureSensorRequest updateTemperatureSensorRequest)
        {
            try
            {
                _temperatureSensorService.UpdateTemperatureSensorAsync(
                    _mapper.Map<UpdateTemperatureSensorModel>(updateTemperatureSensorRequest));
                if (response)
                {
                    return Ok();
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{SensorId}")]
        public async Task<IActionResult> RemoveTemperatureSensorAsync([FromRoute] RemoveTemperatureSensorRequest removeTemperatureSensorRequest)
        {
            try
            {
                _temperatureSensorService.RemoveTemperatureSensorAsync(
                    _mapper.Map<RemoveTemperatureSensorModel>(removeTemperatureSensorRequest));
                if (response)
                {
                    return Ok();
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{SensorId}")]
        public async Task<IActionResult> GetTemperatureSensorAsync([FromRoute] GetTemperatureSensorRequest getTemperatureSensorRequest)
        {
            try
            {
                var response = await _temperatureSensorService.GetTemperatureSensorAsync(
                    _mapper.Map<GetTemperatureSensorModel>(getTemperatureSensorRequest));
                if (response is not null)
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTemperatureSensorsAsync([FromRoute] GetTemperatureSensorsRequest getTemperatureSensorsRequest)
        {
            try
            {
                var response = await _temperatureSensorService.GetTemperatureSensorsAsync(
                    _mapper.Map<GetTemperatureSensorModel>(getTemperatureSensorsRequest));
                if (response is not null)
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}