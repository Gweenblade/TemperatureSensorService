using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Core.InternalModels;
using TemperatureSensor.Infrastructure.DatabaseUtility.DbContexts;
using TemperatureSensor.Infrastructure.DatabaseUtility.Entities;

namespace TemperatureSensor.Infrastructure.DatabaseUtility.Service
{
    public class TemperatureSensorRepository : ITemperatureSensorRepository
    {
        private readonly TemperatureSensorContext _context;
        private readonly IMapper _mapper;

        public TemperatureSensorRepository(TemperatureSensorContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> CreateTemperatureSensorAsync(CreateTemperatureSensorModel createTemperatureSensorModel)
        {
            var existingSensor = await _context.TemperatureSensors
                .AsNoTracking().FirstOrDefaultAsync(x => x.SensorId == createTemperatureSensorModel.SensorId);
            if (existingSensor != null)
            {
                return false;
            }
            else
            {
                _context.TemperatureSensors.Add(_mapper.Map<TemperatureSensorEntity>(createTemperatureSensorModel));
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<TemperatureSensorDto> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel)
        {
            var sensorEntity =
                await _context.TemperatureSensors.Where(x => x.SensorId == getTemperatureSensorModel.SensorId).FirstOrDefaultAsync();
            return _mapper.Map<TemperatureSensorDto>(sensorEntity);
        }

        public async Task<IEnumerable<TemperatureSensorDto>> GetTemperatureSensorsAsync(GetTemperatureSensorsModel getTemperatureSensorModel)
        {
            var sensorDtos = await _context.TemperatureSensors
                .Where(x => x.Meridian >= getTemperatureSensorModel.Meridian).ToListAsync();
            return _mapper.Map<IEnumerable<TemperatureSensorDto>>(sensorDtos);
        }


        public async Task RemoveTemperatureSensor(RemoveTemperatureSensorModel removeTemperatureSensorModel)
        {
            var entity = await _context.TemperatureSensors.AsNoTracking().Where(x => x.SensorId == removeTemperatureSensorModel.SensorId)
                .FirstAsync();
            _context.TemperatureSensors.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateTemperatureSensorAsync(UpdateTemperatureSensorModel updateTemperatureSensorModel)
        {

            var existingSensor =
                    await _context.TemperatureSensors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == updateTemperatureSensorModel.Id);
            if (existingSensor == null)
            {
                return false;
            }
            else
            {
                _context.TemperatureSensors.Update(
                    _mapper.Map<TemperatureSensorEntity>(updateTemperatureSensorModel));
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
