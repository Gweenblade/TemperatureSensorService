namespace TemperatureSensor.Core.Interfaces
{
    internal interface ITemperatureNotificationService
    {
        public Task<bool> SendNotificationToDrive();
    }
}
