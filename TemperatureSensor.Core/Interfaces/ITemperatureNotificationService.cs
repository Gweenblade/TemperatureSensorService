namespace TemperatureSensor.Core.Interfaces
{
    internal interface ITemperatureNotificationService
    {
        public Task SendNotificationToDrive();
    }
}
