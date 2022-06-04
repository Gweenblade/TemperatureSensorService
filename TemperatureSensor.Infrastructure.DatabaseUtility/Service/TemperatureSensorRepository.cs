using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Core.InternalModels;
using TemperatureSensor.Infrastructure.DatabaseUtility.DbContexts;
using TemperatureSensor.Infrastructure.DatabaseUtility.Entities;

namespace TemperatureSensor.Infrastructure.DatabaseUtility.Service
{
    internal class TemperatureSensorRepository : ITemperatureSensorRepository
    {
        private readonly TemperatureSensorContext _context;
        private readonly IMapper _mapper;

        public TemperatureSensorRepository(TemperatureSensorContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public void CreateTemperatureSensorAsync(CreateTemperatureSensorModel createTemperatureSensorModel)
        {
            _context.TemperatureSensors.Add(_mapper.Map<TemperatureSensorEntity>(createTemperatureSensorModel));
        }

        public async Task<TemperatureSensorDto> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel)
        {
            var sensorEntity = 
                await _context.TemperatureSensors.Where(x => x.SensorId == getTemperatureSensorModel.SensorId).FirstAsync();
            var sensorDto = sensorEntity != null ? _mapper.Map<TemperatureSensorDto>(sensorEntity) : null;
            return sensorDto;
        }

        public async Task<IEnumerable<TemperatureSensorDto>> GetTemperatureSensorsAsync(GetTemperatureSensorsModel getTemperatureSensorModel)
        {
            var sensorDtos = await _context.TemperatureSensors
                .Where(x => x.Meridian > getTemperatureSensorModel.Meridian).ToListAsync();
            return _mapper.Map<IEnumerable<TemperatureSensorDto>>(sensorDtos);
        }


        public async Task RemoveTemperatureSensor(RemoveTemperatureSensorModel removeTemperatureSensorModel)
        {
            var entity = await _context.TemperatureSensors.Where(x => x.Id == removeTemperatureSensorModel.Id)
                .FirstAsync();
            _context.TemperatureSensors.Remove(entity);
        }

        public void UpdateTemperatureSensorAsync(UpdateTemperatureSensorModel updateTemperatureSensorModel)
        {
            _context.TemperatureSensors.Update(_mapper.Map<TemperatureSensorEntity>(updateTemperatureSensorModel));
        }
    }
}
