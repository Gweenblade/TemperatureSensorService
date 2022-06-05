namespace TemperatureSensor.Core.Interfaces
{
    internal interface ITemperatureNotificationJob
    {
        public Task SendNotificationToDrive();
    }
}
