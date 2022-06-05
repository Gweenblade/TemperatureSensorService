using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Newtonsoft.Json;
using Quartz;
using System.Text;
using TemperatureSensor.Core.Infrastructure;
using TemperatureSensor.Core.Interfaces;
using TemperatureSensor.Core.InternalModels;

namespace TemperatureSensor.Core.Jobs
{
    [DisallowConcurrentExecution]
    internal class TemperatureNotificationJob : IJob, ITemperatureNotificationJob
    {
        private readonly string PathToServiceAccountKey = "../key.json";

        private readonly string Directory = "1kMzODBDotvTLaei_Ci01LltJAxetSDL3";

        private DriveService _service;
        ITemperatureSensorRepository _temperatureSensorRepository;
        public TemperatureNotificationJob(ITemperatureSensorRepository temperatureSensorRepository)
        {
            _temperatureSensorRepository = temperatureSensorRepository;
            _service ??= CreateDriveService();
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await SendNotificationToDrive();
        }

        public async Task SendNotificationToDrive()
        {
            var sensorsReport = await CreateTemperatureSensorReport();

            var fileName = CreateLocalFile(sensorsReport);

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = $"{DateTime.UtcNow.ToShortDateString()}-{DateTime.UtcNow.ToShortTimeString()}",
                Parents = new List<string>() { $"{Directory}" },
            };

            await UploadFileToDrive(fileName, fileMetadata);

            RemoveLocalFile(fileName);
        }

        private DriveService CreateDriveService()
        {
            var creditential = GoogleCredential.FromFile(PathToServiceAccountKey)
                .CreateScoped(DriveService.ScopeConstants.Drive);

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = creditential
            });
        }

        private async Task<string> CreateTemperatureSensorReport()
        {
            var temperatureSensors = await _temperatureSensorRepository.GetTemperatureSensorsAsync(new GetTemperatureSensorsModel());

            return JsonConvert.SerializeObject(temperatureSensors, Formatting.Indented);
        }

        private string CreateLocalFile(string sensorsReport)
        {
            var localFileName = $"{DateTime.UtcNow.ToShortTimeString()}-report.json";
            using (var x = System.IO.File.Create($"{localFileName}"))
            {
                byte[] bytes = Encoding.ASCII.GetBytes(sensorsReport);
                x.Write(bytes);
            };
            return localFileName;
        }

        private async Task UploadFileToDrive(string fileName, Google.Apis.Drive.v3.Data.File fileMetadata)
        {
            using (var fsSource = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var request = _service.Files.Create(fileMetadata, fsSource, "text/plain");
                var results = await request.UploadAsync(CancellationToken.None);

                if (results.Status == UploadStatus.Failed)
                {
                    Console.WriteLine($"Error uploading file: {results.Exception.Message}");
                }
            }
        }

        private void RemoveLocalFile(string fileName) => System.IO.File.Delete(fileName);
    }
}
