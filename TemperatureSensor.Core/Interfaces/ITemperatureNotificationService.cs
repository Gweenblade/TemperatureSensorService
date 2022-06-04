using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureSensor.Core.Interfaces
{
    internal interface ITemperatureNotificationService
    {
        public Task<bool> SendNotificationToDrive();
    }
}
