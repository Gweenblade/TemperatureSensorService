using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureSensor.Core.Interfaces;

namespace TemperatureSensor.Core.Services
{
    internal class TemperatureNotificationService : ITemperatureNotificationService
    {
        public Task<bool> SendNotificationToDrive()
        {
            throw new NotImplementedException();
        }
    }
}
