using AutoMapper;
using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Core.InternalModels;
using TemperatureSensor.Models.Requests;
using TemperatureSensor.Models.Responses;

namespace TemperatureSensor.Infrastructure.WebApi
{
    internal class TemperatureSensorProfiles : Profile
    {
        public TemperatureSensorProfiles()
        {
            CreateMap<CreateTemperatureSensorRequest, CreateTemperatureSensorModel>();
            CreateMap<GetTemperatureSensorRequest, GetTemperatureSensorModel>();
            CreateMap<RemoveTemperatureSensorRequest, RemoveTemperatureSensorModel>();
            CreateMap<UpdateTemperatureSensorRequest, UpdateTemperatureSensorModel>();
            CreateMap<GetTemperatureSensorsRequest, GetTemperatureSensorsModel>();

            CreateMap<TemperatureSensorDto, GetTemperatureSensorResponse>();
        }
    }
}
