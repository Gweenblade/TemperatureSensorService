using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureSensor.Core.InternalModels;

namespace TemperatureSensor.Core.Interfaces
{
    internal interface ITemperatureSensorService
    {
        Task<string> GetTemperatureSensorAsync(GetTemperatureSensorModel getTemperatureSensorModel);
        Task<bool> CreateTemperatureSensorAsync(CreateTemperatureSensorModel createTemperatureSensorModel);
        Task<bool> RemoveTemperatureSensorAsync(RemoveTemperatureSensorModel removeTemperatureSensorModel);
        Task<bool> UpdateTemperatureSensorAsync(UpdateTemperatureSensorModel updateTemperatureSensorModel);
    }
}
