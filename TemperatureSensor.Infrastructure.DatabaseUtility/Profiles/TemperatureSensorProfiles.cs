using AutoMapper;
using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.InternalModels;
using TemperatureSensor.Infrastructure.DatabaseUtility.Entities;

namespace TemperatureSensor.Infrastructure.DatabaseUtility.Profiles
{
    public class TemperatureSensorProfiles : Profile
    {
        public TemperatureSensorProfiles()
        {
            CreateMap<TemperatureSensorEntity, TemperatureSensorDto>();
            CreateMap<CreateTemperatureSensorModel, TemperatureSensorEntity>();
            CreateMap<RemoveTemperatureSensorModel, TemperatureSensorEntity>();
            CreateMap<UpdateTemperatureSensorModel, TemperatureSensorEntity>();
        }
    }
}
