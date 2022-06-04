namespace TemperatureSensor.Core.Infrastructure
{
    public interface IDatabaseUtility
    {
        Task<bool> CreateDatabaseEntry();
        Task<bool> UpdateDatabaseEntry();
        Task<bool> GetDatabaseEntry();
        Task<bool> RemoveDatabaseEntry();
    }
}
