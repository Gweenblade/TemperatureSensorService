using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TemperatureSensor.Core.Dtos;
using TemperatureSensor.Infrastructure.DatabaseUtility.Entities;

namespace TemperatureSensor.Infrastructure.DatabaseUtility.Profiles
{
    public class TemperatureSensorProfiles : Profile
    {
        public TemperatureSensorProfiles()
        {
            CreateMap<TemperatureSensorEntity, TemperatureSensorDto>();
        }
    }
}
