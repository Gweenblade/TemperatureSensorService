using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureSensor.Core.Interfaces;
using TemperatureSensor.Core.InternalModels;

namespace TemperatureSensor.Core.Services
{
    internal class TemperatureSensorService : ITemperatureSensorService
    {
        public Task<bool> CreateTemperatureSensorAsync(CreateTemperatureSensorModel createTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveTemperatureSensorAsync(RemoveTemperatureSensorModel removeTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTemperatureSensorAsync(UpdateTemperatureSensorModel updateTemperatureSensorModel)
        {
            throw new NotImplementedException();
        }
    }
}
